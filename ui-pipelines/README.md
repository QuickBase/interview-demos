# Quick Base Pipelines Front End Craft Demo

## General Description

The purpose of the craft demo is to give us a jumping off point for discussion
of your approach to solving a problem and of your code. 

We expect this project about 1-2 hours to complete. 

We know not everyone has unlimited time to work on interview projects and we do not expect
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

## The scenario

The project is to create a control to add metadata to a user's Pipeline, including the channels used, labels, etc. 

## Design

Do not worry about styling the UI

![](https://github.com/QuickBase/interview-demos/blob/master/ui-pipelines/ui-pipelines-design.png)

## Core Requirements / Tasks

1. The builder can select a single channel for the Pipeline from a dropdown - the list of channels is to be fetched
   from this API: [https://www.pipelines.quickbase.com/api/-/channels](https://www.pipelines.quickbase.com/api/-/channels) You will probably run into CORS issues. Please think about what this is and how to get around this but you can also use the mock service to get through this.
1. The builder can add and remove tags to the Pipeline. These tags can be anything a user can enter. Duplicates tags are not allowed. There cannot be more than 5 tags total.
1. The Label field is required. Validate that following rules and notify the builder if there are any
   validation issues.
1. Add a button that allows the builder to clear the form and start fresh.
1. The submit button should create a json object and post it to any endpoint that returns some response. After the form is submitted, the user should have some indication that there is a success, 
   and the state of the form should be reset.

## Non-Core Requirements / Tasks

We dont expect you to code them but prepared to talk about these scenarios

* Think of being responsive. Allow the form to be responsive and work on mobile devices in addition to
  desktop.
* Think about error handling from the APIs, slow APIs, timeouts. Think about what kind of APIs would serve this feature the best.
* Think about tests. What kind of tests would you write if you had more time?
* Think about Accessibility and Internationalization best practices. Please form an opinion on how to do these well.
* Think about reusability. Refactor the button component such that it could be used by other developers
  and maintain the same style and behavior (e.g., for a custom component
  library). For example, let's say we want all of our submit buttons to show a
  loading indicator after they are clicked. How could we create a component that
  has that behavior that would be shared across all instances of the submit
  button? Please be prepared to at least anaswer questions around the principles of reusability.
