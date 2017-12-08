# Quick Base Craft Demo for the PHP Developer

## General Description

The purpose of the craft demo is to give us a jumping off point for discussion
of your approach to solving a problem and of your code. We are interested in
learning how you approach this problem and go about solving it.

We expect this project to take experienced developers familiar with PHP about
1-2 hours to complete. We know not everyone has unlimited time to work on
interview projects and we do not expect that everyone completes all of the
requirements. However, you may be asked how you might have solved a requirement
you didn't get to if you had more time. By the same token if you want to extend
the requirements (e.g., adding more extensive user input validation), please
feel free to do so as you see fit. Generally, we prefer higher code quality over
more features for the purpose of the demo if you start to run out of time.

Use of your favorite libraries or frameworks is welcomed but optional. The
requirements outlined below can be completed with or without a framework. We
like using frameworks to help us deliver customer value faster, but be careful
that you can still demonstrate _your_ coding ability. For example, you might
want to hand-code one of the validations on the form even if the framework
already provides it.

Your demo should run on whichever web browser you prefer.

## Craft Demo Presentation Outline

We have created a PowerPoint template which covers an outline of what we would
like to talk about during the first section of your interview before you share
your craft demo. Feel free to use the template provided or make your own. For
developers, we are more interested in your code than your PowerPoint skills, so
plan your prep time accordingly.

[PowerPoint Template and Craft Demo Outline](https://github.com/QuickBase/interview-demos/blob/master/QuickBase_CraftDemo_PresentationTemplate.pptx)

When you show off your craft demo, we will ask you to show us how it works from
a user's perspective (e.g., filling out the form and clicking "save"). After
that, we will ask for a tour of your code with a focus on how you got the core
functionality to work.

## The scenario

Assume you are working on the admin controls of a product that allows users to
set up their own input forms (e.g., how Google Forms, SurveyMonkey, or Quick
Base allow you to build a survey with a multiple choice field). The project is
to create a control to modify the properties of a multiple choice field. It’s
not necessary to have the control actually build a multiple choice field; assume
that functionality is handled by a service and you just need to interact with
its APIs.

## Design

A User Experience (UX) designer has created the following image and requirements
for the multiple choice editor you are building. It is a first draft. We are
collaborative here at Quick Base and as a developer you can suggest alternatives
to the items below. We often have conversations between developers and UX
designers about a spec before we go build it. Unfortunately, in this setup
scenario, you can't talk with the UX designer so feel free to imagine you had
the conversation and make changes you think would be worthwhile.

![](https://github.com/QuickBase/interview-demos/blob/master/php/php-craft-demo-form.png)

## Core Requirements / Tasks

1. The submit button should post this form to your PHP application and validate
   the data on the server.
1. Validate the following rules and notify the user if there are any validation
   issues.
   * The Label field is required.
   * Duplicates choices are not allowed.
   * There cannot be more than 50 choices total.
1. If the default value is not one of the choices, it should be added to the
   list of choices when the field is saved.
1. For the purpose of the demo, you may want the form to keep its values after
   the form is submitted. This helps demonstrate the prior requirement (that the
   default value is added).
1. Add a button that allows the user to clear the form and start fresh.

## Stretch Requirements / Tasks

These are bonus tasks to consider. Complete the core tasks before attempting one
of these. You can also feel free to consider your own ideas for extension if you
have time to complete additional requirements. These are only suggestions.

1. Imagine that your web application is part of a micro-service architecture. In
   our made-up architecture, you need to send the data from the form you built
   to another service that will generate the UI code for the final survey. From
   the PHP application, send the content of this form to
   http://www.mocky.io/v2/5a21e7692d00008c33e0042e as json if the data passes
   validation. Send back a response to the user about whether this api request
   succeeded or failed.
1. In modern web applications, we typically don't wait to send the data to the
   server in order to alert a response might be invalid. Consider adding some
   client-side validation to your form. For example, if the label field is not
   filled out, alert the user and disable the "Save changes" button. Remember to
   provide a way to turn this functionality off so that we can also see your
   server-side validation working from the core requirements.
1. Have you ever closed the browser accidentally when working on something?
   Yeah, me too. Let's help the user out by populating the form with the input
   they were working on if they accidentally close the browser.
