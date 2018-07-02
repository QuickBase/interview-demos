# Quick Base Craft Demo | Integration Specialist

## Craft Demo Presentation Outline

We have created a PowerPoint template which covers an outline of what we would like to talk about during the first section of your interview before you share your craft demo. Feel free to use the template provided or make your own. We are more interested in your code than your PowerPoint skills, so plan your prep time accordingly.

[PowerPoint Template and Craft Demo Outline](https://github.com/QuickBase/interview-demos/blob/master/QuickBase_CraftDemo_PresentationTemplate.pptx)

## General Description

The purpose of the craft demo is to give us a jumping-off-point for discussion of your approach to solving a problem and of your code. We are interested in learning how you approach this problem and go about solving it.

We expect this project to take experienced developers about two to four hours to complete. We know not everyone has unlimited time to work on interview projects and we do not expect that everyone completes all of the requirements. However, you may be asked how you might have solved a requirement you missed had you been able to work on this project without time constraints. Additionally, if you want to extend the project beyond the listed requirements (e.g., tracking additional data points in the 'Tweet Tracker' app), please feel free to do so as you see fit. Please note that we prefer higher-code quality over additional features if you start to run out of time.

Use of your favorite libraries, SDKs and frameworks is welcomed but optional. The project outlined below can be completed with or without these tools.

Please be prepared to demo your solution in a working development environment on the day of your interview. When you present your craft demo, we will ask you to describe how you arrived at your solution. After that, we will ask for a tour of your code with a focus on how you arrived at the core functionality and any design decisions and/or tradeoffs you made during the process.

## Demo Project Outline

The Quick Base marketing team has a launched a brand-awareness campaign that is running for the next year and you have been tasked with tracking tweets about the company for the length of this engagement. You have been asked specifically to search Twitter for tweets that contain hashtags from a list compiled by our marketing team and store them in a Quick Base app for future investigation by our business analysts. 

## Demo Project Requirements

1. Your code should collect 100 or more tweets from this year that include any of the following hashtags:
    * #QuickBase
    * #NoCode
    * #LowCode
    * #QBCommunitySummit
1. Collected tweets should be de-duplicated in the Quick Base app. For example, if a tweet contains both the #NoCode and #LowCode hashtags it should only be stored once in the app with both hashtags captured in the 'Hashtag' field.
1. All fields in the destination Quick Base app should be populated for each tweet.
1. Your project output should be a service or application that adheres to both Quick Base and Twitter API best practices. You can write your code in any language or use any framework you prefer. As a data integration specialist at Quick Base, you will likely be working with a code base written in PHP.
1. Industry-standard practices for testing, logging and error-handling are expected as time permits.

## FAQ

### **Working with the Quick Base API**

1. Create a Quick Base trial account at https://www.quickbase.com/trial-register. Please make sure to set the company name as: QBSmokeTest-999.
1. Clone the 'Tweet Tracker' Quick Base application from the Quick Base Exchange using these directions: https://help.quickbase.com/user-assistance/create_database_from_template.html.
1. Create an application token to securely access your Quick Base app through our APIs by following the documentation here: https://help.quickbase.com/user-assistance/app_tokens.html.
1. Follow the documentation at https://help.quickbase.com/api-guide/index.html to send requests to specific Quick Base APIs.

### **Working with the Twitter API**

1. Create a Twitter App at https://apps.twitter.com/ in order for your code to access the Twitter API.
1. Obtain the Consumer Key and Consumer Secret from your Twitter app and authenticate against the Twitter API auth endpoint for 'Application-only authentication' as described here: https://developer.twitter.com/en/docs/basics/authentication/overview/application-only.html
1. Follow the documentation at https://developer.twitter.com/en/docs/basics/getting-started to send requests to specific Twitter APIs.
