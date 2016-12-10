//
//  LHJSONParserRecipe.m
//
//  Created by PIC  on 7/23/15
//  Copyright (c) 2015 __MyCompanyName__. All rights reserved.
//

#import "LHJSONParserRecipe.h"
#import "LHJSONParserFilterDictionary.h"
#import "LHJSONParserIngredients.h"
#import "LHJSONParserTagsDictionary.h"
#import "LHJSONParserInformationProperties.h"
#import "LHJSONParserNutrition.h"
#import "LHJSONParserSteps.h"


NSString *const kLHJSONParserRecipeLocked = @"locked";
NSString *const kLHJSONParserRecipeLanguage = @"language";
NSString *const kLHJSONParserRecipeSearchString = @"searchString";
NSString *const kLHJSONParserRecipeFilterDictionary = @"filterDictionary";
NSString *const kLHJSONParserRecipeEnglishTitle = @"englishTitle";
NSString *const kLHJSONParserRecipeIngredients = @"ingredients";
NSString *const kLHJSONParserRecipeTagsDictionary = @"tagsDictionary";
NSString *const kLHJSONParserRecipeKeywords = @"keywords";
NSString *const kLHJSONParserRecipeSourceType = @"sourceType";
NSString *const kLHJSONParserRecipeTotalTime = @"totalTime";
NSString *const kLHJSONParserRecipeCoverImage = @"coverImage";
NSString *const kLHJSONParserRecipeServings = @"servings";
NSString *const kLHJSONParserRecipeRecipeEnglishDescription = @"recipeEnglishDescription";
NSString *const kLHJSONParserRecipeRecipeTitle = @"recipeTitle";
NSString *const kLHJSONParserRecipeRecipeDescription = @"recipeDescription";
NSString *const kLHJSONParserRecipeRecipeType = @"recipeType";
NSString *const kLHJSONParserRecipeInformationProperties = @"informationProperties";
NSString *const kLHJSONParserRecipeNutrition = @"nutrition";
NSString *const kLHJSONParserRecipeChallenges = @"challenges";
NSString *const kLHJSONParserRecipeSteps = @"steps";
NSString *const kLHJSONParserRecipeMappingId = @"mappingId";


@interface LHJSONParserRecipe ()

- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict;

@end

@implementation LHJSONParserRecipe

@synthesize locked = _locked;
@synthesize language = _language;
@synthesize searchString = _searchString;
@synthesize filterDictionary = _filterDictionary;
@synthesize englishTitle = _englishTitle;
@synthesize ingredients = _ingredients;
@synthesize tagsDictionary = _tagsDictionary;
@synthesize keywords = _keywords;
@synthesize sourceType = _sourceType;
@synthesize totalTime = _totalTime;
@synthesize coverImage = _coverImage;
@synthesize servings = _servings;
@synthesize recipeEnglishDescription = _recipeEnglishDescription;
@synthesize recipeTitle = _recipeTitle;
@synthesize recipeDescription = _recipeDescription;
@synthesize recipeType = _recipeType;
@synthesize informationProperties = _informationProperties;
@synthesize nutrition = _nutrition;
@synthesize challenges = _challenges;
@synthesize steps = _steps;
@synthesize mappingId = _mappingId;


+ (instancetype)modelObjectWithDictionary:(NSDictionary *)dict {
    return [[self alloc] initWithDictionary:dict];
}

- (instancetype)initWithDictionary:(NSDictionary *)dict {
    self = [super init];
    
    // This check serves to make sure that a non-NSDictionary object
    // passed into the model class doesn't break the parsing.
    if(self && [dict isKindOfClass:[NSDictionary class]]) {
            self.locked = [self objectOrNilForKey:kLHJSONParserRecipeLocked fromDictionary:dict];
            self.language = [self objectOrNilForKey:kLHJSONParserRecipeLanguage fromDictionary:dict];
            self.searchString = [self objectOrNilForKey:kLHJSONParserRecipeSearchString fromDictionary:dict];
            self.filterDictionary = [LHJSONParserFilterDictionary modelObjectWithDictionary:[dict objectForKey:kLHJSONParserRecipeFilterDictionary]];
            self.englishTitle = [self objectOrNilForKey:kLHJSONParserRecipeEnglishTitle fromDictionary:dict];
    NSObject *receivedLHJSONParserIngredients = [dict objectForKey:kLHJSONParserRecipeIngredients];
    NSMutableArray *parsedLHJSONParserIngredients = [NSMutableArray array];
    if ([receivedLHJSONParserIngredients isKindOfClass:[NSArray class]]) {
        for (NSDictionary *item in (NSArray *)receivedLHJSONParserIngredients) {
            if ([item isKindOfClass:[NSDictionary class]]) {
                [parsedLHJSONParserIngredients addObject:[LHJSONParserIngredients modelObjectWithDictionary:item]];
            }
       }
    } else if ([receivedLHJSONParserIngredients isKindOfClass:[NSDictionary class]]) {
       [parsedLHJSONParserIngredients addObject:[LHJSONParserIngredients modelObjectWithDictionary:(NSDictionary *)receivedLHJSONParserIngredients]];
    }

    self.ingredients = [NSArray arrayWithArray:parsedLHJSONParserIngredients];
            self.tagsDictionary = [LHJSONParserTagsDictionary modelObjectWithDictionary:[dict objectForKey:kLHJSONParserRecipeTagsDictionary]];
            self.keywords = [self objectOrNilForKey:kLHJSONParserRecipeKeywords fromDictionary:dict];
            self.sourceType = [self objectOrNilForKey:kLHJSONParserRecipeSourceType fromDictionary:dict];
            self.totalTime = [[self objectOrNilForKey:kLHJSONParserRecipeTotalTime fromDictionary:dict] doubleValue];
            self.coverImage = [self objectOrNilForKey:kLHJSONParserRecipeCoverImage fromDictionary:dict];
            self.servings = [self objectOrNilForKey:kLHJSONParserRecipeServings fromDictionary:dict];
            self.recipeEnglishDescription = [self objectOrNilForKey:kLHJSONParserRecipeRecipeEnglishDescription fromDictionary:dict];
            self.recipeTitle = [self objectOrNilForKey:kLHJSONParserRecipeRecipeTitle fromDictionary:dict];
            self.recipeDescription = [self objectOrNilForKey:kLHJSONParserRecipeRecipeDescription fromDictionary:dict];
            self.recipeType = [self objectOrNilForKey:kLHJSONParserRecipeRecipeType fromDictionary:dict];
            self.informationProperties = [LHJSONParserInformationProperties modelObjectWithDictionary:[dict objectForKey:kLHJSONParserRecipeInformationProperties]];
    NSObject *receivedLHJSONParserNutrition = [dict objectForKey:kLHJSONParserRecipeNutrition];
    NSMutableArray *parsedLHJSONParserNutrition = [NSMutableArray array];
    if ([receivedLHJSONParserNutrition isKindOfClass:[NSArray class]]) {
        for (NSDictionary *item in (NSArray *)receivedLHJSONParserNutrition) {
            if ([item isKindOfClass:[NSDictionary class]]) {
                [parsedLHJSONParserNutrition addObject:[LHJSONParserNutrition modelObjectWithDictionary:item]];
            }
       }
    } else if ([receivedLHJSONParserNutrition isKindOfClass:[NSDictionary class]]) {
       [parsedLHJSONParserNutrition addObject:[LHJSONParserNutrition modelObjectWithDictionary:(NSDictionary *)receivedLHJSONParserNutrition]];
    }

    self.nutrition = [NSArray arrayWithArray:parsedLHJSONParserNutrition];
            self.challenges = [self objectOrNilForKey:kLHJSONParserRecipeChallenges fromDictionary:dict];
    NSObject *receivedLHJSONParserSteps = [dict objectForKey:kLHJSONParserRecipeSteps];
    NSMutableArray *parsedLHJSONParserSteps = [NSMutableArray array];
    if ([receivedLHJSONParserSteps isKindOfClass:[NSArray class]]) {
        for (NSDictionary *item in (NSArray *)receivedLHJSONParserSteps) {
            if ([item isKindOfClass:[NSDictionary class]]) {
                [parsedLHJSONParserSteps addObject:[LHJSONParserSteps modelObjectWithDictionary:item]];
            }
       }
    } else if ([receivedLHJSONParserSteps isKindOfClass:[NSDictionary class]]) {
       [parsedLHJSONParserSteps addObject:[LHJSONParserSteps modelObjectWithDictionary:(NSDictionary *)receivedLHJSONParserSteps]];
    }

    self.steps = [NSArray arrayWithArray:parsedLHJSONParserSteps];
            self.mappingId = [self objectOrNilForKey:kLHJSONParserRecipeMappingId fromDictionary:dict];

    }
    
    return self;
    
}

- (NSDictionary *)dictionaryRepresentation {
    NSMutableDictionary *mutableDict = [NSMutableDictionary dictionary];
    [mutableDict setValue:self.locked forKey:kLHJSONParserRecipeLocked];
    [mutableDict setValue:self.language forKey:kLHJSONParserRecipeLanguage];
    [mutableDict setValue:self.searchString forKey:kLHJSONParserRecipeSearchString];
    [mutableDict setValue:[self.filterDictionary dictionaryRepresentation] forKey:kLHJSONParserRecipeFilterDictionary];
    [mutableDict setValue:self.englishTitle forKey:kLHJSONParserRecipeEnglishTitle];
    NSMutableArray *tempArrayForIngredients = [NSMutableArray array];
    for (NSObject *subArrayObject in self.ingredients) {
        if([subArrayObject respondsToSelector:@selector(dictionaryRepresentation)]) {
            // This class is a model object
            [tempArrayForIngredients addObject:[subArrayObject performSelector:@selector(dictionaryRepresentation)]];
        } else {
            // Generic object
            [tempArrayForIngredients addObject:subArrayObject];
        }
    }
    [mutableDict setValue:[NSArray arrayWithArray:tempArrayForIngredients] forKey:kLHJSONParserRecipeIngredients];
    [mutableDict setValue:[self.tagsDictionary dictionaryRepresentation] forKey:kLHJSONParserRecipeTagsDictionary];
    [mutableDict setValue:self.keywords forKey:kLHJSONParserRecipeKeywords];
    [mutableDict setValue:self.sourceType forKey:kLHJSONParserRecipeSourceType];
    [mutableDict setValue:[NSNumber numberWithDouble:self.totalTime] forKey:kLHJSONParserRecipeTotalTime];
    [mutableDict setValue:self.coverImage forKey:kLHJSONParserRecipeCoverImage];
    [mutableDict setValue:self.servings forKey:kLHJSONParserRecipeServings];
    [mutableDict setValue:self.recipeEnglishDescription forKey:kLHJSONParserRecipeRecipeEnglishDescription];
    [mutableDict setValue:self.recipeTitle forKey:kLHJSONParserRecipeRecipeTitle];
    [mutableDict setValue:self.recipeDescription forKey:kLHJSONParserRecipeRecipeDescription];
    [mutableDict setValue:self.recipeType forKey:kLHJSONParserRecipeRecipeType];
    [mutableDict setValue:[self.informationProperties dictionaryRepresentation] forKey:kLHJSONParserRecipeInformationProperties];
    NSMutableArray *tempArrayForNutrition = [NSMutableArray array];
    for (NSObject *subArrayObject in self.nutrition) {
        if([subArrayObject respondsToSelector:@selector(dictionaryRepresentation)]) {
            // This class is a model object
            [tempArrayForNutrition addObject:[subArrayObject performSelector:@selector(dictionaryRepresentation)]];
        } else {
            // Generic object
            [tempArrayForNutrition addObject:subArrayObject];
        }
    }
    [mutableDict setValue:[NSArray arrayWithArray:tempArrayForNutrition] forKey:kLHJSONParserRecipeNutrition];
    NSMutableArray *tempArrayForChallenges = [NSMutableArray array];
    for (NSObject *subArrayObject in self.challenges) {
        if([subArrayObject respondsToSelector:@selector(dictionaryRepresentation)]) {
            // This class is a model object
            [tempArrayForChallenges addObject:[subArrayObject performSelector:@selector(dictionaryRepresentation)]];
        } else {
            // Generic object
            [tempArrayForChallenges addObject:subArrayObject];
        }
    }
    [mutableDict setValue:[NSArray arrayWithArray:tempArrayForChallenges] forKey:kLHJSONParserRecipeChallenges];
    NSMutableArray *tempArrayForSteps = [NSMutableArray array];
    for (NSObject *subArrayObject in self.steps) {
        if([subArrayObject respondsToSelector:@selector(dictionaryRepresentation)]) {
            // This class is a model object
            [tempArrayForSteps addObject:[subArrayObject performSelector:@selector(dictionaryRepresentation)]];
        } else {
            // Generic object
            [tempArrayForSteps addObject:subArrayObject];
        }
    }
    [mutableDict setValue:[NSArray arrayWithArray:tempArrayForSteps] forKey:kLHJSONParserRecipeSteps];
    [mutableDict setValue:self.mappingId forKey:kLHJSONParserRecipeMappingId];

    return [NSDictionary dictionaryWithDictionary:mutableDict];
}

- (NSString *)description  {
    return [NSString stringWithFormat:@"%@", [self dictionaryRepresentation]];
}

#pragma mark - Helper Method
- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict {
    id object = [dict objectForKey:aKey];
    return [object isEqual:[NSNull null]] ? nil : object;
}


#pragma mark - NSCoding Methods

- (id)initWithCoder:(NSCoder *)aDecoder {
    self = [super init];

    self.locked = [aDecoder decodeObjectForKey:kLHJSONParserRecipeLocked];
    self.language = [aDecoder decodeObjectForKey:kLHJSONParserRecipeLanguage];
    self.searchString = [aDecoder decodeObjectForKey:kLHJSONParserRecipeSearchString];
    self.filterDictionary = [aDecoder decodeObjectForKey:kLHJSONParserRecipeFilterDictionary];
    self.englishTitle = [aDecoder decodeObjectForKey:kLHJSONParserRecipeEnglishTitle];
    self.ingredients = [aDecoder decodeObjectForKey:kLHJSONParserRecipeIngredients];
    self.tagsDictionary = [aDecoder decodeObjectForKey:kLHJSONParserRecipeTagsDictionary];
    self.keywords = [aDecoder decodeObjectForKey:kLHJSONParserRecipeKeywords];
    self.sourceType = [aDecoder decodeObjectForKey:kLHJSONParserRecipeSourceType];
    self.totalTime = [aDecoder decodeDoubleForKey:kLHJSONParserRecipeTotalTime];
    self.coverImage = [aDecoder decodeObjectForKey:kLHJSONParserRecipeCoverImage];
    self.servings = [aDecoder decodeObjectForKey:kLHJSONParserRecipeServings];
    self.recipeEnglishDescription = [aDecoder decodeObjectForKey:kLHJSONParserRecipeRecipeEnglishDescription];
    self.recipeTitle = [aDecoder decodeObjectForKey:kLHJSONParserRecipeRecipeTitle];
    self.recipeDescription = [aDecoder decodeObjectForKey:kLHJSONParserRecipeRecipeDescription];
    self.recipeType = [aDecoder decodeObjectForKey:kLHJSONParserRecipeRecipeType];
    self.informationProperties = [aDecoder decodeObjectForKey:kLHJSONParserRecipeInformationProperties];
    self.nutrition = [aDecoder decodeObjectForKey:kLHJSONParserRecipeNutrition];
    self.challenges = [aDecoder decodeObjectForKey:kLHJSONParserRecipeChallenges];
    self.steps = [aDecoder decodeObjectForKey:kLHJSONParserRecipeSteps];
    self.mappingId = [aDecoder decodeObjectForKey:kLHJSONParserRecipeMappingId];
    return self;
}

- (void)encodeWithCoder:(NSCoder *)aCoder {
    [aCoder encodeObject:_locked forKey:kLHJSONParserRecipeLocked];
    [aCoder encodeObject:_language forKey:kLHJSONParserRecipeLanguage];
    [aCoder encodeObject:_searchString forKey:kLHJSONParserRecipeSearchString];
    [aCoder encodeObject:_filterDictionary forKey:kLHJSONParserRecipeFilterDictionary];
    [aCoder encodeObject:_englishTitle forKey:kLHJSONParserRecipeEnglishTitle];
    [aCoder encodeObject:_ingredients forKey:kLHJSONParserRecipeIngredients];
    [aCoder encodeObject:_tagsDictionary forKey:kLHJSONParserRecipeTagsDictionary];
    [aCoder encodeObject:_keywords forKey:kLHJSONParserRecipeKeywords];
    [aCoder encodeObject:_sourceType forKey:kLHJSONParserRecipeSourceType];
    [aCoder encodeDouble:_totalTime forKey:kLHJSONParserRecipeTotalTime];
    [aCoder encodeObject:_coverImage forKey:kLHJSONParserRecipeCoverImage];
    [aCoder encodeObject:_servings forKey:kLHJSONParserRecipeServings];
    [aCoder encodeObject:_recipeEnglishDescription forKey:kLHJSONParserRecipeRecipeEnglishDescription];
    [aCoder encodeObject:_recipeTitle forKey:kLHJSONParserRecipeRecipeTitle];
    [aCoder encodeObject:_recipeDescription forKey:kLHJSONParserRecipeRecipeDescription];
    [aCoder encodeObject:_recipeType forKey:kLHJSONParserRecipeRecipeType];
    [aCoder encodeObject:_informationProperties forKey:kLHJSONParserRecipeInformationProperties];
    [aCoder encodeObject:_nutrition forKey:kLHJSONParserRecipeNutrition];
    [aCoder encodeObject:_challenges forKey:kLHJSONParserRecipeChallenges];
    [aCoder encodeObject:_steps forKey:kLHJSONParserRecipeSteps];
    [aCoder encodeObject:_mappingId forKey:kLHJSONParserRecipeMappingId];
}

- (id)copyWithZone:(NSZone *)zone {
    LHJSONParserRecipe *copy = [[LHJSONParserRecipe alloc] init];
    
    if (copy) {

        copy.locked = [self.locked copyWithZone:zone];
        copy.language = [self.language copyWithZone:zone];
        copy.searchString = [self.searchString copyWithZone:zone];
        copy.filterDictionary = [self.filterDictionary copyWithZone:zone];
        copy.englishTitle = [self.englishTitle copyWithZone:zone];
        copy.ingredients = [self.ingredients copyWithZone:zone];
        copy.tagsDictionary = [self.tagsDictionary copyWithZone:zone];
        copy.keywords = [self.keywords copyWithZone:zone];
        copy.sourceType = [self.sourceType copyWithZone:zone];
        copy.totalTime = self.totalTime;
        copy.coverImage = [self.coverImage copyWithZone:zone];
        copy.servings = [self.servings copyWithZone:zone];
        copy.recipeEnglishDescription = [self.recipeEnglishDescription copyWithZone:zone];
        copy.recipeTitle = [self.recipeTitle copyWithZone:zone];
        copy.recipeDescription = [self.recipeDescription copyWithZone:zone];
        copy.recipeType = [self.recipeType copyWithZone:zone];
        copy.informationProperties = [self.informationProperties copyWithZone:zone];
        copy.nutrition = [self.nutrition copyWithZone:zone];
        copy.challenges = [self.challenges copyWithZone:zone];
        copy.steps = [self.steps copyWithZone:zone];
        copy.mappingId = [self.mappingId copyWithZone:zone];
    }
    
    return copy;
}


@end
