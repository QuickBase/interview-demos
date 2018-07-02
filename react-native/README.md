# Quick Base Craft Demo | React Native

## Craft Demo Presentation Outline

We have created a PowerPoint template which covers an outline of what we would like to talk about during the first section of your interview before you share your craft demo. Feel free to use the template provided or make your own. We are more interested in your code than your PowerPoint skills, so plan your prep time accordingly.

[PowerPoint Template and Craft Demo Outline](https://github.com/QuickBase/interview-demos/blob/master/QuickBase_CraftDemo_PresentationTemplate.pptx)

One of our Quick Base partners has asked us to create a feature inside our react-native application. 
After an internal review, we have found a significant portion of our user base that could benefit from their feature. 
You have been given the opportunity to create a proof of concept. 

## General Description

The purpose of the craft demo is to give us a jumping-off-point for discussion of your approach to solving a problem and of your code. We are interested in learning how you approach this problem and go about solving it.

We expect this project to take experienced developers about two to four hours to complete. We know not everyone has unlimited time to work on interview projects and we do not expect that everyone completes all of the requirements. However, you may be asked how you might have solved a requirement you missed had you been able to work on this project without time constraints. Additionally, if you want to extend the project beyond the listed requirements (e.g., tracking additional data points in the 'Tweet Tracker' app), please feel free to do so as you see fit. Please note that we prefer higher-code quality over additional features if you start to run out of time.

Use of your favorite libraries, SDKs and frameworks is welcomed but optional. The project outlined below can be completed with or without these tools.

Please be prepared to demo your solution in a working development environment on the day of your interview. When you present your craft demo, we will ask you to describe how you arrived at your solution. After that, we will ask for a tour of your code with a focus on how you arrived at the core functionality and any design decisions and/or tradeoffs you made during the process.

## User story
Sally's garage manages a high volume of inventory for many independent auto mechanics using a Quick Base application. 
Sally is hoping to use a native iOS application to add new models to their inventory tracking Quick Base app. 

## Technical Requirements

1. Clone our demo app from the App Exchange (see the [FAQ](#faq))
1. Recreate a React native version of the input form and post the data via the quick base api to your app. 
1. Create a `react-native` view that pushes data to the Quick Base API

## Stretch Goals
1. Add a barcode scanner to their react native view
1. Wrap our current mobile web experience in a UI `webview`, but still allow barcode scanner functionality on that specific field

### User story for stretch goals
Sally is hoping to be able to scan a barcode using our native application and have that data pushed into the "Barcode" 
field in their Quick Base application. The mobile app should allow one of the floor managers to view the provided add 
new record web page, and upon clicking the "Barcode" field, there should be a barcode scanner (fine to use QR codes 
for testing) that scans and then returns that data to the add new record view.   
    
    
### FAQ
1. [Create a Quick Base trial account](https://www.quickbase.com/trial-register). Please make sure to set the company name as: `QBSmokeTest-999`
1. Create a copy of the `react native craft demo` app by following [the exchange instructions](https://help.quickbase.com/user-assistance/create_database_from_template.html)
1. Create an application token to securely access your Quick Base app through our APIs by [following the documentation](https://help.quickbase.com/user-assistance/app_tokens.html)