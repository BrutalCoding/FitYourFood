package com.philips.cl.di.ka.healthydrinks.connections;

import android.content.Context;

import com.philips.cl.di.ka.healthydrinks.utils.AppLogger;
import com.philips.cl.di.ka.healthydrinks.utils.AppSharedPreferences;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

/**
 * Created by Sangeetha on 2/17/16.
 */
public class ConnectionHandler {


    private OnNetworkTransactionCompletedListener listener;
    private static final int BUFFER_SIZE = 8192;
    private boolean isErrorOccured;

    private boolean checkIfUpdateAvailable(Context context, List<String> value, String key) {
        String lastModified = handleImproperData(Arrays.toString(value.toArray()));
        String savedLastModified = getModifiedInfo(context, key);
        Date serverDate = null;
        Date syncedServerDate = null;
        try {
            SimpleDateFormat dateFormat = new SimpleDateFormat("EEE, d MMM yyyy HH:mm:ss Z",Locale.ENGLISH);
            serverDate = dateFormat.parse(lastModified);
            if (savedLastModified != null)
                syncedServerDate = dateFormat.parse(savedLastModified);

        } catch (Exception e) {
            e.printStackTrace();
            AppLogger.e(getClass().getSimpleName(), "ERROR IS" + e);
        }
        if (serverDate != null && (syncedServerDate == null || serverDate.after(syncedServerDate))) {
            AppLogger.d("scene7","last modified date in app set to "+lastModified + " key is "+key);
            storeLastModifiedInfo(context, key, lastModified);
            return true;
        } else
            return false;

    }

    private String handleImproperData(String mLastModifiedString) {
        mLastModifiedString = mLastModifiedString.trim();
        //TODO comment the below line if data format from server has changed(i.e enclosing the jsonObject in [] )
        if (mLastModifiedString.startsWith("[") && mLastModifiedString.endsWith("]"))
            mLastModifiedString = mLastModifiedString.substring(1, mLastModifiedString.length() - 1);

        return mLastModifiedString;
    }

    private boolean storeLastModifiedInfo(Context context, String key, String value) {
        synchronized (AppSharedPreferences.getInstance(context)) {
            return AppSharedPreferences.getInstance(context).saveStringPrefs(key,
                    value);// "Mon, 25 Jan 2016 07:00:14 GMT");
        }
    }

    private String getModifiedInfo(Context context, String key) {
        synchronized (AppSharedPreferences.getInstance(context)) {
            return AppSharedPreferences.getInstance(context).getStringPrefs(key);// "Mon, 25 Jan 2016 07:00:14 GMT");
        }
    }

    public void setOnNetworkTransactionCompletedListener(OnNetworkTransactionCompletedListener listener) {
        this.listener = listener;
    }

    private void fireRespectiveListener(String url_name, boolean isAvailable, boolean isError) {
        if (listener == null && url_name == null)
            return;

        switch (url_name) {
            case "recipes_url":
                if (!isError) {
                    if(isAvailable)
                        listener.OnNetworkTransactionCompleted(Utils.OPERATION_FETCHED_RECIPES, url_name, null);
                    else
                    listener.OnNetworkTransactionCompleted(Utils.RECIPES_UPTO_DATE, url_name, null);

                }else  if (isError)
                    listener.OnNetworkTransactionCompleted(Utils.DATA_FETCH_ERROR_RECIPES, url_name, null);
                break;

            case "nutrition_url":
                if (!isError) {
                    if (isAvailable)
                        listener.OnNetworkTransactionCompleted(Utils.OPERATION_FETCHED_NUTRITION, url_name, null);
                    else
                        listener.OnNetworkTransactionCompleted(Utils.NUTRITION_UPTO_DATE, url_name, null);
                }else if (isError)
                    listener.OnNetworkTransactionCompleted(Utils.DATA_FETCH_ERROR_NUTRITION, url_name, null);
                break;
            case "meet_the_range_url":
                if (!isError) {
                    if (isAvailable)
                        listener.OnNetworkTransactionCompleted(Utils.OPERATION_FETCHED_MEET_THE_RANGE, url_name, null);
                    else
                        listener.OnNetworkTransactionCompleted(Utils.MEET_THE_RANGE_UPTO_DATE, url_name, null);
                }else if (isError)
                    listener.OnNetworkTransactionCompleted(Utils.DATA_FETCH_ERROR_MEET_THE_RANGE, url_name, null);
                break;
            case "mapping_ids_url":
                if (!isError) {
                    if (isAvailable)
                        listener.OnNetworkTransactionCompleted(Utils.OPERATION_FETCHED_MAPPING_IDS, url_name, null);
                    else
                        listener.OnNetworkTransactionCompleted(Utils.MAPPING_IDS_UPTO_DATE, url_name, null);
                }else if (isError)
                    listener.OnNetworkTransactionCompleted(Utils.DATA_FETCH_ERROR_MAPPING_IDS, url_name, null);
                break;
        }

    }

    public boolean readPropertiesForUpdate(String mUrl,Context context,String key)
    {
        boolean isAvailable = false;

        try {
            HttpURLConnection httpURLConnection;
            URL url = new URL(mUrl+"?req=props,json");
            httpURLConnection = (HttpURLConnection) url.openConnection();

            Map<String, List<String>> map = httpURLConnection.getHeaderFields();
            List<String> lastModifiedList = map.get("Last-Modified");
            if (lastModifiedList != null && !lastModifiedList.isEmpty()) {

                isAvailable = checkIfUpdateAvailable(context, lastModifiedList, key);
                AppLogger.d("scene7","is update available "+isAvailable);

            }
            else
            {
                //last modified is null then report an error.
                //fireRespectiveListener(key, false, true);
                isErrorOccured = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
            //fireRespectiveListener(key, false, true);
            isErrorOccured = true;
        }
        return isAvailable;
    }

    public void download(Context context, String urlLink, String zipName, final String key) {
        boolean isAvailable = readPropertiesForUpdate(urlLink, context, key);
        if (isAvailable) {
            try {

                URL url = new URL(urlLink);

                URLConnection urlConnection = url.openConnection();
                urlConnection.connect();

                InputStream is = null;

                try {
                    is = url.openStream();

                    DataInputStream dis = new DataInputStream(is);

                    byte[] buffer = new byte[1024];
                    int length;

                    FileOutputStream fos = new FileOutputStream(Utils.getBasePath(context) + "/" + zipName);
                    while ((length = dis.read(buffer)) > 0) {
                        fos.write(buffer, 0, length);
                    }
                } catch (IOException e) {
                    throw new RuntimeException(e);
                } finally {
                    if (is != null) {
                        try {
                            is.close();
                            is = null;
                        } catch (Exception ignore) {
                            ;
                        }
                    }
                }
                unzip(Utils.getBasePath(context) + "/" + zipName, Utils.getBasePath(context) + "/");
                fireRespectiveListener(key, true, false);
            } catch (Exception e) {

                e.printStackTrace();
                fireRespectiveListener(key, false, true);
//                downloadFailed(resultReceiver);
            }
        } else {
            if(isErrorOccured)
                fireRespectiveListener(key, false, true);
            else
                fireRespectiveListener(key, false, false);
        }


    }



    private void unzip(String src, String dest){

        final int BUFFER_SIZE = 4096;

        BufferedOutputStream bufferedOutputStream = null;
        FileInputStream fileInputStream;
        try {
            fileInputStream = new FileInputStream(src);
            ZipInputStream zipInputStream
                    = new ZipInputStream(new BufferedInputStream(fileInputStream));
            ZipEntry zipEntry;

            while ((zipEntry = zipInputStream.getNextEntry()) != null){

                String zipEntryName = zipEntry.getName();
                File file = new File(dest + zipEntryName);

                if (file.exists()){

                } else {
                    if(zipEntry.isDirectory()){
                        file.mkdirs();
                    }else{
                        byte buffer[] = new byte[BUFFER_SIZE];
                        FileOutputStream fileOutputStream = new FileOutputStream(file);
                        bufferedOutputStream
                                = new BufferedOutputStream(fileOutputStream, BUFFER_SIZE);
                        int count;

                        while ((count
                                = zipInputStream.read(buffer, 0, BUFFER_SIZE)) != -1) {
                            bufferedOutputStream.write(buffer, 0, count);
                        }

                        bufferedOutputStream.flush();
                        bufferedOutputStream.close();
                    }
                }
            }
            zipInputStream.close();
        } catch (FileNotFoundException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        finally {
            File zipFile=new File(src);
            if(zipFile.exists())
                zipFile.delete();
        }
    }

}
