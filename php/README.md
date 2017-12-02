# Quick Base craft demo for PHP Developer
## The demo
The purpose of the craft demo is to give us a jumping off point for discussion of your approach to solving a problem and of your code.  We are interested in learning how you approach this problem and go about solving it. We expect this will take less than 1-2 hours of your time so you are not required to spend more than a couple of hours. We would like you to start working on the requirements and we do not expect you to fulfill all of the requirements listed below. By the same token if you want to extend the requirements or validation, please feel free to do so as you see fit.

Use of your favorite libraries is permitted but optional.  You will demo this from a browser - you are free to use any web server.  

## The scenario

Assume you are working on the admin controls of a product that allows users to set up their own input forms. The project is to create a control to modify the properties of a multiple choice field. It’s not necessary to have the control actually build a multiple choice field; assume that functionality is handled by a service and you just need to interact with its APIs.

## Design
![](https://github.com/madhu-rajagopalan-qb/qb-interview-artifacts/blob/master/php-developer/php-craft-demo-form.png)

## Requirements / Tasks
1. The submit button should create a json object and post it to  http://www.mocky.io/v2/5a21e7692d00008c33e0042e.
2. Validate the following rules and notify the user if there are any validation issues. You could also do the validation using a Javascript library.
  * The Label field is required.
  * Duplicates choices are not allowed.
  * There cannot be more than 50 choices altogether.
3. If the default value is not one of the choices, it should be added to the list of choices when the field is saved.
4. If the save API request failed the user should be notified.
