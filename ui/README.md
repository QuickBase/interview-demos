# Interview materials for UX dev
## The demo
The purpose of the craft demo is to give us a jumping off point for discussion of your approach to solving a problem and of your code.  We do not expect you to fulfill all the requirements listed below.  Choose from the list of tasks what you can get done in an hour or two and that best highlights your skills. We would rather see one task done well than all the tasks attempted but none working!

Use of your favorite libraries is permitted but optional.  You will demo this from a browser - you are free to use any or no webserver.  

## The scenario

Assume you are working on the admin controls of a product that allows users to set up their own input forms. The project is to create a control to modify the properties of a multiple choice field. It’s not necessary to have the control actually build a multiple choice field; assume that functionality is handled by a service and you just need to interact with its APIs (and for the purpose of this demo, just interact with MockFieldService.js). 

## Design
![](https://github.com/ckeswani/ux-dev-interview-materials/blob/master/spec/FieldBuilderRegular.png)

*For screens where width > 420*

![](https://github.com/ckeswani/ux-dev-interview-materials/blob/master/spec/FieldBuilderCompact.png)

*For screens where width <= 420.*

The mockup is intended to give an idea of the desired functionality--you can make different visual design choices, or you can choose to focus on the functional requirements and have a bare-bones visual.

## Requirements / Tasks 
1. The submit button should create a json object and post it to  http://www.mocky.io/v2/566061f21200008e3aabd919.  It should also log the post data to the console.  (Add a function to FieldService in MockFieldService.js.)
2. Validate the following rules and notify the user if there are any validation issues:
  * The Label field is required.
  * Individual choices cannot be longer than 40 characters. If a choice is longer than 40 characters, the excess characters must be visually distinct.
  * There cannot be more than 50 choices altogether.
3. If the default value is not one of the choices, it should be added to the list of choices when the field is saved.
4. Layout must be responsive to multiple device sizes (phone, tablet, desktop browser).  The spec shows the layout at full size and phone size.
