# Quick Base Craft Demo | React Native

There are two key parts of the craft demo:

* A very brief presentation outlined below in "Craft Demo Presentation Outline". You can use the powerpoint provided or your own, but we would like you to be able to speak to the questions in the linked Powerpoint provided.
* A working project that solves the problem outlined below. Your new mobile application should allow you to display and add parts and save them to a Quickbase Application. You can use whichever tools you are most comfortable with (React Native, Ionic, Flutter, etc.) though most candidates do complete it with React Native. You should use the appropriate tooling for the framework you choose to spin up a base project (e.g., [Create React Native App](https://reactnative.dev/docs/environment-setup)) and solve the items below.

## Craft Demo Presentation Outline

We have created a PowerPoint template which covers an outline of what we would like to talk about during the first section of your interview before you share your craft demo. Feel free to use the template provided or make your own. We are more interested in your code than your PowerPoint skills, so plan your prep time accordingly.

[PowerPoint Template and Craft Demo Outline](https://github.com/QuickBase/interview-demos/blob/master/QuickBase_CraftDemo_PresentationTemplate.pptx)

One of our Quick Base partners has asked us to create a feature inside our react-native application. 
After an internal review, we have found a significant portion of our user base that could benefit from their feature. 
You have been given the opportunity to create a proof of concept. 

## General Description

The purpose of the craft demo is to give us a jumping-off-point for discussion of your approach to solving a problem and of your code. We are interested in learning how you approach this problem and go about solving it.

We expect this project to take experienced developers about two to four hours to complete. We know not everyone has unlimited time to work on interview projects and we do not expect that everyone completes all of the requirements. However, you may be asked how you might have solved a requirement you missed had you been able to work on this project without time constraints. Additionally, if you want to extend the project beyond the listed requirements (e.g. completing some of the stretch goals, or being creative with your own requirements), please feel free to do so as you see fit. Please note that we prefer higher-code quality over additional features if you start to run out of time.

Use of your favorite libraries, SDKs and frameworks is welcomed but optional. The project outlined below can be completed with or without these tools.

Please be prepared to demo your solution in a working development environment on the day of your interview. When you present your craft demo, we will ask you to describe how you arrived at your solution. After that, we will ask for a tour of your code with a focus on how you arrived at the core functionality and any design decisions and/or trade-offs you made during the process.

### User story
Sally's garage manages a high volume of inventory for many independent auto mechanics using a Quick Base application. 
Sally is hoping to use a native iOS or Android application to add new models to their inventory tracking Quick Base app. 

### Technical Requirements

1. Clone our demo app from the App Exchange (see the [FAQ](#faq))
1. Recreate a React native version of the `create new part` form and post the data via the quick base api to your app.
    1. To get to the create new record view, go to `My Apps`
    1. Under my apps, select `React Native Craft Demo`
    1. After selecting your app, navigate to `Parts`
    1. Click `+ New Part` 
1. When the user clicks the "Add" button on the form, a new record should be created in the Quick Base app in the parts tables with the data the user entered. **Hint: You can use one of our APIs to add a new record. See the [API Help documentation](https://help.quickbase.com/api-guide/index.html#add_record.html%3FTocPath%3DQuick%2520Base%2520API%2520Call%2520Reference%7C_____6)** 

## Setting up your Quick Base app <a name="faq"/>
1. [Create a Quick Base trial account](https://www.quickbase.com/trial-register). Please make sure to set the company name as: `QBSmokeTest-999`
1. Create a copy of the `react native craft demo` app by following [the exchange instructions](https://help.quickbase.com/user-assistance/create_database_from_template.html)
1. Create an application token to securely access your Quick Base app through our APIs by [following the documentation](https://help.quickbase.com/user-assistance/app_tokens.html)


## Stretch Goals
If you have time, you can optionally complete one or more of the stretch goals listed below **or come up with your own ideas for functionality you want to add to the app**.

### Stretch Goal User Story
Sally is hoping to be able to scan a barcode using our native application and have that data pushed into the "Barcode" 
field in their Quick Base application. The mobile app should allow one of the floor managers to view the provided add 
new record web page, and upon clicking the "Barcode" field, there should be a barcode scanner (fine to use QR codes 
for testing) that scans and then returns that data to the add new record view.   

### Stretch Goals - Technical Requirements
1. Add a barcode scanner to their react native view
    * Open up a barcode scanner when the user taps the barcode field on the form. 
    * The barcode field will be populated with the data from the QR and/or barcode that is scanned.
1. Wrap our current mobile web experience in a UI `webview`, but still allow barcode scanner functionality on the `barcode` field
    
