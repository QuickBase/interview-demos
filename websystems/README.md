Quickbase Web Systems Front End Craft Demo

## General Description

The purpose of the craft demo is to give us a jumping off point for discussion of your approach to solving a problem and of your code. We are interested in learning how you approach this problem and go about solving it.

**We expect this project to take experienced developers familiar with web technologies (HTML, CSS, JavaScript) about 2-3 hours to complete. We know not everyone has unlimited time to work on interview projects and we do not expect that everyone completes all of the requirements.** However, you may be asked how you might have solved a requirement you didn't get to if you had more time. By the same token if you want to extend the requirements, please feel free to do so as you see fit. Generally, we prefer higher code quality over more features for the purpose of the demo if you start to run out of time.

Use of your favorite libraries or frameworks is welcomed but optional. The requirements outlined below can be completed with or without a framework. We like using frameworks to help us deliver customer value faster, but be careful that you can still demonstrate your coding ability. For example, you might want to hand-code one of the requirements even if the framework already provides it.

Your demo should run on whichever web browser you prefer.

## Candidate Exercise Presentation Outline

We have created a PowerPoint template which covers an outline of what we would like to talk about during the first section of your interview before you share your craft demo. Feel free to use the template provided or make your own. For developers, we are more interested in your code than your PowerPoint skills, so plan your prep time accordingly.

[PowerPoint Template and Craft Demo Outline](https://github.com/QuickBase/interview-demos/blob/567d0b1929ffa440ccc189abdbf5052f2dcd66fb/websystems/Quickbase_CandidateExercise_PresentationTemplate.pptx)

When you show off your craft demo, we will ask you to show us how it works from a visitor's perspective looking at the finished site. After that, we will ask for a tour of your code with a focus on how you got the core functionality to work.

## Design
A User Experience (UX) designer has created the following image and requirements for the component you are building. We are collaborative here at Quickbase and as a developer you can suggest alternatives to the items below. We often have conversations between developers and UX designers about a spec before we go build it. Unfortunately, in this setup scenario, you can't talk with the UX designer so feel free to imagine you had the conversation and make changes you think would be worthwhile.

# Core Requirements
You work for the Quickbase Web Systems team. You have been given the following ticket to accomplish as part of the current sprint. The Web Systems team does use Bootstrap grid, the BEM naming conventions, and SCSS. We discourage the use of JavaScript inline styles. However, you are welcome to use your own methodologies to finish the required work for this [ticket](https://github.com/QuickBase/interview-demos/blob/a980da9ba2ebc5cec06f6a9ba3e2908f084a726d/websystems/Craft_Demo_Ticket.md).

1. Recreate the provided mockups using the ticket information provided. Your code should be responsive and match the provided mockups for [mobile](https://github.com/QuickBase/interview-demos/blob/a980da9ba2ebc5cec06f6a9ba3e2908f084a726d/websystems/Web-Systems__Craft-Demo-Mockup--Mobile.jpg) and [desktop](https://github.com/QuickBase/interview-demos/blob/a980da9ba2ebc5cec06f6a9ba3e2908f084a726d/websystems/Web-Systems__Craft-Demo-Mockup--Desktop.jpg) views. 

2. Take the provided JSON and for each of the objects in the array, create a card as seen in the mockup.

3. Each object may have a different “category” property. Depending on the object category, the card’s banner will have a different background color. Please refer to the ticket for the color values for each category.

4. If an object doesn’t have an image, do not create a card for that particular object.

5. If there is no link URL, do not show the link at all, but do show the card with the rest of the content provided.



# Stretch Goals
- Create a reusable button component that you insert into each of the cards.

- Provide some of your CSS code in SCSS format, including nesting, inheritance, variables, etc.

- Add “National Park” as a default title if there is no title provided for a card.

- Referring to #3 in the Core Requirements, have the title color also change based on the object’s category property.

- Add a class to feature a card in the row. The featured card will appear first in the card list and have:

  - The background color of the card will be Elm with White text.

  - A button background color of Chrome with Black text.

- Have all cards maintain a consistent height across a row, regardless of content. The link buttons inside the card should be aligned to the bottom, even if there is space between the button and card text.

- Add hover states to buttons.

  - Asparagus should hover to Elm. The text color should change from Black to White.

  - Carrot should hover to Geraldine.

  - Elm should hover to Asparagus. The text color should change from White to Black.

  - If you are doing the featured card stretch goal as well, the featured card button color should hover to Picton Blue. The text color should stay black.
