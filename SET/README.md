# Materials for Software Engineer in Test interviews for Quickbase

## Purpose
The purpose of this exercise is not to give a "gotcha" question or puzzle, but a straight-forward (albeit contrived)
example of the kind of requirement that might arise in a real project so that we have shared context for a technical 
conversation during the interview. We are interested in how you approach a project, so you should feel free to add new 
class files as well modify the files that are provided as you see fit. Use of your favorite libraries or frameworks is
fine, but not required. How you demonstrate the correctness of your implementation is up to you.

## Exercise
Write a UI end to end user test class (language of your choice) that launches a web browser and navigates to the WebdriverIO website (http://webdriver.io). Click on the 'API' link in the top navigation bar and load their API documenation (http://webdriver.io/api.html_). Use their search functionality on this page to search their API for the text 'click'. Collect and return the link names in the left nav section that are returned as a result of the search. Have your test verify that the following 5 action results are returned (click, doubleClick, leftClick, middleClick, rightClick). If possible use the Page Object model for element locators and helper functions.
As a second task create another set of test cases that would further test the functionality of this search widget.

