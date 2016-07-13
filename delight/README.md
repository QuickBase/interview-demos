# Delight Team Craft Demo

Below are descriptions of three issues in QuickBase.  Sign up for a trial from our website and then reproduce and troubleshoot each issue.  During the demo you should be able to talk through and/or show your troubleshooting approach and what changes you think should be made to fix the bug.  You should use browser developer tools and any resources on our site (for example the help) as needed.

## Issue 1: Date and Date/Time fields with "Show day of week" enabled appear as center justified in reports

Steps to reproduce:  

1. In an application with a date or date/time field and data, view that field on a report.  
2. Open a Date field's properties page and click the Show the day of the week checkbox under Display section  
3. View the report with your date field again and notice the values for the column is center justified  
4. Go back to the field's properties and uncheck the Show the day of the week checkbox and check the Show the month as a name  checkbox.  Notice the values are correctly justified; aligned with other data in other fields.  

Screenshot of issue:

<img src = https://cloud.githubusercontent.com/assets/4675652/16807737/98ef4722-48e7-11e6-9a17-a32090fbb58c.png />

## Issue 2: Parse Error in Custom Field Access when a field name contains a \

Steps to Reproduce:  

1.	Modify a field name to contain a \  
2.	In the permissions settings for one of the roles in the application, try to choose Custom Access for Field Level permissions for the table of the field that you modified in step 1.  You will see an error like this:  

<img src = https://cloud.githubusercontent.com/assets/4675652/16807739/9ad9bec8-48e7-11e6-9f89-af5306088ef6.png />

## Issue 3: Column headers on paginated Table Home Page reports don’t freeze after the first page

Steps to Reproduce:  

1.	Create an app/report with enough data in it that there is pagination  
2.	Make that report the table home page report for the table  
3.	View the table home page for the table.  Notice that if you scroll down on the first page, the column headers freeze at the top.  If you go to the second page of the report and scroll down, the headers no longer freeze.  

Screenshot page 1: has frozen headers

<img src = https://cloud.githubusercontent.com/assets/4675652/16807742/9ce27f5c-48e7-11e6-9eef-a0759833153a.png />

Screenshot page 2: no frozen headers

<img src = https://cloud.githubusercontent.com/assets/4675652/16807745/9f4d05a0-48e7-11e6-9cb9-c749c37988cc.png />

