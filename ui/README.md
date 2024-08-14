# Quickbase Front End Craft Demo

## General Description

The purpose of the craft demo is to give us a jumping off point for discussion
of your approach to solving a problem and of your code. We are interested in
learning how you approach this problem and go about solving it.

We expect this project to take experienced developers familiar with web
technologies (HTML, CSS, javascript) about 1-2 hours to complete. We know not
everyone has unlimited time to work on interview projects and we do not expect
that everyone completes all of the requirements. However, you may be asked how
you might have solved a requirement you didn't get to if you had more time. By
the same token if you want to extend the requirements (e.g., adding more
extensive user input validation), please feel free to do so as you see fit.
Generally, we prefer higher code quality over more features for the purpose of
the demo if you start to run out of time.

Use of your favorite libraries or frameworks is welcomed but optional. The
requirements outlined below can be completed with or without a framework. We
like using frameworks to help us deliver customer value faster, but be careful
that you can still demonstrate _your_ coding ability. For example, you might
want to hand-code one of the validations on the form even if the framework
already provides it.

Your demo should run on whichever web browser you prefer.

## Candidate Exercise Presentation Outline

[optional] it is optional to use the presentation slide. You can jump right into the code as well.

We have created a PowerPoint template which covers an outline of what we would
like to talk about during the first section of your interview before you share
your craft demo. Feel free to use the template provided or make your own. For
developers, we are more interested in your code than your PowerPoint skills, so
plan your prep time accordingly.

[PowerPoint Template and Craft Demo Outline](https://github.com/QuickBase/interview-demos/blob/master/ui/Quickbase_CandidateExercise_PresentationTemplate.pptx)

When you show off your craft demo, we will ask you to show us how it works from
a user's perspective (e.g., filling out the form and clicking "save"). After
that, we will ask for a tour of your code with a focus on how you got the core
functionality to work.

## The scenario

Assume you are working on the admin controls of a product that allows builders
to set up their own input forms (e.g., how Google Forms, SurveyMonkey, or Quick
Base allow you to build a survey with a multiple choice field). The project is
to create a control to modify the properties of a multiple choice field. It’s
not necessary to have the control actually build a multiple choice field; assume
that functionality is handled by a service and you just need to interact with
its APIs.

## Design

**Note for XD Developer Position:** You may want to consider a more in depth
analysis of this spec or greater changes to the spec that demonstrate how you
approach XD problems.

A User Experience (UX) designer has created the following image and requirements
for the multiple choice editor you are building. It is a first draft. We are
collaborative here at Quickbase and as a developer you can suggest alternatives
to the items below. We often have conversations between developers and UX
designers about a spec before we go build it. Unfortunately, in this setup
scenario, you can't talk with the UX designer so feel free to imagine you had
the conversation and make changes you think would be worthwhile.

![](https://github.com/QuickBase/interview-demos/blob/master/php/php-craft-demo-form.png)

## Core Requirements / Tasks

1. The builder can add and remove choices from the list of choices. In the visual spec
   provided, the builder adds and removes choices in a textarea element.
   Individual items are separated by a new line. Feel free to modify this
   interaction to meet the requirement of being able to add and remove choices.
1. Validate the following rules and notify the builder if there are any
   validation issues.
   * The Label field is required.
   * Duplicates choices are not allowed.
   * There cannot be more than 50 choices total.
1. If the default value is not one of the choices, it should be added to the
   list of choices when the field is saved.
1. For the purpose of the demo, you may want the form to keep its values after
   the form is submitted. This helps demonstrate the prior requirement (that the
   default value is added).
1. Add a button that allows the builder to clear the form and start fresh.
1. Generate a Mocky endpoint to use for this craft demo or alternatively use another service/method of your preference to achieve this.  Steps to generate a Mocky endpoint to post data to:
    1. Navigate to [Mocky](https://designer.mocky.io/).
    1. Click on "New Mock".
    1. Add details about your API call here including a generic response.
    1. Ensure "Never Expire" is checked at the bottom.
    1. Click "Generate My HTTP Response" button at the bottom of the screen.
    1. Copy the "Mock URL" that is provided.
1. The submit button should create a json object and post it to the link that you 
generated in the Mocky service above.  It should also log the post data to the console. 
You can add a function to FieldService in [MockFieldService.js](https://github.com/QuickBase/interview-demos/blob/master/ui/js/MockService.js) to accomplish this, but everything is up 
to you.  Feel free to modify or change anything you would like as long as it meets the 
minimum requirement of posting json data to the back-end endpoint.

## Stretch Requirements / Tasks

These are bonus tasks to consider. Complete the core tasks before attempting one
of these. You can also feel free to consider your own ideas for extension if you
have time to complete additional requirements. These are only suggestions.

* Add some unit tests using Jest, React testing library or similar
* Allow the form to be responsive and work on mobile devices in addition to
  desktop.
* Have you ever closed the browser accidentally when working on something? Yeah,
  me too. Let's help the user out by populating the form with the input they
  were working on if they accidentally close the browser.
* The database that stores this does not allow individual choices in the list of
  choices to be longer than 40 characters. Add client-side validation such that
  excess characters are visually distinct if the choice is longer than 40
  characters. I.e., if a user enters the word that is longer than 40 characters,
  the characters above 40 would be highlighted in red.
* Refactor the button component such that it could be used by other developers
  and maintain the same style and behavior (e.g., for a custom component
  library). For example, let's say we want all of our submit buttons to show a
  loading indicator after they are clicked. How could we create a component that
  has that behavior that would be shared across all instances of the submit
  button?

## FAQ

* **What is a "builder" vs. an "end user"?**

  This spec is designed for a "builder". A "builder" is a user of the product
  that creates forms.

  An "end user" is a user of the product that submits data using the forms that
  were created by the builder.

  For example, let's say I own an apartment building. As a "builder", I would
  create a form that allows people to submit work requests if something in their
  apartment breaks.

  Once I publish the form, the tenants that live in my apartment building, the
  "end users", would fill out this form to let me know something is broken in
  their apartment.

* **What is that "Type: Multi-select Text" in the spec image?**

  In the full version of this spec, that is a drop-down. A builder could select
  "multi-select" (allow end users to select multiple options) or "single-select"
  (end users can only pick one of the options).

* **What is the checkbox for "A value is required"?**

  After the builder creates their form with this multiple choice option, the end
  user be required to pick a choice before they could submit the form.
