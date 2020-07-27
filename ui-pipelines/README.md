# Quick Base Pipelines Front End Craft Demo

## General Description

The purpose of the craft demo is to give us a jumping off point for discussion
of your approach to solving a problem and of your code. We are interested in
learning how you approach this problem and go about solving it.

We expect this project to take experienced developers familiar with web
technologies (HTML, CSS, javascript, React) about 1-2 hours to complete. We know not
everyone has unlimited time to work on interview projects and we do not expect
that everyone completes all of the requirements. However, you may be asked how
you might have solved a requirement you didn't get to if you had more time. By
the same token if you want to extend the requirements (e.g., adding more
extensive user input validation), please feel free to do so as you see fit.
Generally, we prefer higher code quality over more features for the purpose of
the demo if you start to run out of time.

Use React + any additional libraries or packages you need. We
like using frameworks to help us deliver customer value faster, but be careful
that you can still demonstrate _your_ coding ability. For example, you might
want to hand-code one of the validations on the form even if the framework
already provides it.

Your demo should run on whichever web browser you prefer.

## Craft Demo Presentation

When you show off your craft demo, we will ask you to show us how it works from
a user's perspective (e.g., filling out the form and clicking "save"). After
that, we will ask for a tour of your code with a focus on how you got the core
functionality to work.

## The scenario

The project is to create a control to add metadata to a user's Pipeline, including the channels used, labels, etc. 
It’s not necessary to have the control actually build anything further than the metadata form; assume
that further functionality is handled by a service and you just need to interact with
its APIs.

## Design

![](https://github.com/QuickBase/interview-demos/blob/master/ui-pipelines/ui-pipelines-design.png)

## Core Requirements / Tasks

1. The builder can select a channel for the Pipeline from a dropdown - the list of channels is to be fetched
   from this API: [https://www.pipelines.quickbase.com/api/-/channels](https://www.pipelines.quickbase.com/api/-/channels) You will probably run into CORS issues.
1. The builder can add and remove tags to the Pipeline, where a default set of tags is visible.
1. Validate the following rules and notify the builder if there are any
   validation issues.
   * The Label field is required.
   * Duplicates tags are not allowed.
   * There cannot be more than 5 tags total.
1. After the form is submitted, the user should have some indication that there is a success, 
   and the state of the form should be reset.
1. Add a button that allows the builder to clear the form and start fresh.
1. The submit button should create a json object and post it to an endpoint that returns some response, or you can use:
   [http://www.mocky.io/v2/566061f21200008e3aabd919](http://www.mocky.io/v2/566061f21200008e3aabd919).
   It should also log the post data to the console. You can add a function to
   FieldService in
   [MockPipelineService.js](https://github.com/QuickBase/interview-demos/blob/master/ui-pipelines/js/MockService.js)
   to accomplish this, but everything is up to you. Feel free to modify or
   change anything you would like as long as it meets the minimum requirement of
   posting json data to the back-end endpoint.

## Stretch Requirements / Tasks

These are bonus tasks to consider. Complete the core tasks before attempting one
of these. You can also feel free to consider your own ideas for extension if you
have time to complete additional requirements. These are only suggestions.

* Allow the form to be responsive and work on mobile devices in addition to
  desktop.
* Think about Accessibility and internationalization best practices. Please form an opinion on how to do these well.
* Think about reusability. Refactor the button component such that it could be used by other developers
  and maintain the same style and behavior (e.g., for a custom component
  library). For example, let's say we want all of our submit buttons to show a
  loading indicator after they are clicked. How could we create a component that
  has that behavior that would be shared across all instances of the submit
  button? Please be prepared to at least anaswer questions around the principles of reusability.
