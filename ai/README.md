- The exercise aims to provide a realistic example for a technical discussion, not a "gotcha" question or puzzle.
- We are interested in understanding your approach to tackling a project. How you show the accuracy of your implementation is entirely at your discretion.
- The exercise should take no more than 6 hours. If it's taking longer, you might be overthinking it.
- If you have any questions, please ask us.

## Requirements

### Main Goal
- Create a command-line Python program that returns a best-match
- Below is the  “data set” of 2 applications: "CRM App" and "Inventory App". Assume we will have 100s of these apps, not 1000s.
- Given a new JSON object, return the best-matching application.

In production, the inference will be wrapped in an API, which will be called once per minute. This feature will be integrated into Quickbase's Smart Builder.


### Stretch Goals
- **Optional Data Augmentation**: Use a Large Language Model (LLM) to generate additional App JSONs. Please share the prompts you used.
- **Optional Cloud Integration**: As an optional challenge, you can use AWS Bedrock, GCP, or Azure to generate embeddings or other features to showcase your cloud expertise.
- **Optional Containerization**: You can also containerize your application to demonstrate your operations skills.
- **Optional Performance Optimization**: Enhance system performance by implementing techniques like indexing or caching.
- **Optional Unit Tests**: Unit tests are optional and can be skipped unless they assist you in the process.


### Guardrails
- Use Python 3, and feel free to incorporate any libraries you need for handling requests or mocks.
- Please create a standalone Python program instead of using a Jupyter Notebook.
- Refrain from using libraries, tools, or services that offer `similarity_search`, `recsys`, or `semantic_search` features. We want to evaluate your implementation skills and dive deeper into your ML and data science expertise.



## Preparation for the Craft Demo
- **No Presentation** Required: PowerPoint presentations are not necessary.
- **Documentation**: You may create documents to accompany your code, detailing your decisions.
- **Program Execution**: Ensure your program can be run during the presentation.

Be prepared to answer questions on these topics:
- Data Understanding: Share insights gained from the dataset and how they shaped your approach.
- Similarity Metrics: Justify your choice of similarity metrics based on the data and retrieval task.
- Evaluation Metrics: Explain your selection of evaluation metrics and how they align with the project goals.
- Algorithm, Model Selection, and Hyperparameters: Describe your model selection process, including chosen algorithms and hyperparameters, and explain your reasoning.
- Deployment and Monitoring: Outline your strategy for deploying and monitoring the solution in production.
- Error Handling: Discuss your approach to managing error cases, failures, and negative scenarios.
- Scalability: Explain how your solution can scale with an increasing number of applications or JSON objects.
- Performance Optimization: Detail any techniques you implemented to optimize the solution’s performance.



## Data Set
```
{
  "AppID1": {
    "ai_dict": {
      "name": "CRM App",
      "description": "Customer Relationship Management.",
      "tables": [
        {
          "name": "Companies",
          "recordNoun": "Company",
          "fields": [
            {
              "name": "Company Name",
              "type": "TX"
            },
            {
              "name": "Address",
              "type": "AD"
            },
            {
              "name": "Web",
              "type": "LK"
            },
            {
              "name": "Phone",
              "type": "PH"
            },
            {
              "name": "Industry",
              "type": "TC",
              "choices": [
                "Machine Tools & Accessories",
                "Information & Delivery Services",
                "Business Services",
                "Telecom Services - Domestic",
                "Auto Parts Stores",
                "Drug Related Products",
                "Specialized Health Services",
                "Air Services, Other",
                "Synthetics",
                "Trucking",
                "Specialty Retail, Other",
                "Industrial Equipment & Components",
                "Insurance Brokers",
                "Oil & Gas Drilling & Exploration",
                "Lumber, Wood Production",
                "Electric Utilities",
                "Gas Utilities",
                "Asset Management",
                "Beverages - Soft Drinks",
                "Air Delivery & Freight Services",
                "Appliances",
                "Biotechnology",
                "Toys & Games",
                "Electronic Equipment",
                "Basic Materials Wholesale",
                "Medical Instruments & Supplies",
                "Beverages - Brewers",
                "Farm & Construction Machinery",
                "Copper",
                "Shipping",
                "Restaurants",
                "Security & Protection Services",
                "Business Equipment"
              ]
            },
            {
              "name": "Lead Status",
              "type": "TC",
              "choices": [
                "O1 - New Lead",
                "O2 - Qualified",
                "O3 - Prospect",
                "O4 - Proposal",
                "O5 - Verbal",
                "C - Dead",
                "C - Lost",
                "C - Past Customer",
                "A - Active Customer"
              ]
            },
            {
              "name": "Lead Source",
              "type": "TC",
              "choices": [
                "Direct Mail",
                "Google",
                "Referral",
                "Website",
                "Yahoo"
              ]
            },
            {
              "name": "Assigned To",
              "type": "US"
            },
            {
              "name": "Fax",
              "type": "PH"
            },
            {
              "name": "Time Zone",
              "type": "TX",
              "formula": "Case(Upper([State]),\r\n\"AL\", \"Central\", \"ALABAMA\", \"Central\", \r\n\"AK\", \"Alaska\", \"ALASKA\", \"Alaska\", \r\n\"AZ\", \"Mountain\", \"ARIZONA\", \"Mountain\", \r\n\"AR\", \"Central\", \"ARKANSAS\", \"Central\", \r\n\"CA\", \"Pacific\", \"CALIFORNIA\", \"Pacific\", \r\n\"CO\", \"Mountain\", \"COLORADO\", \"Mountain\", \r\n\"CT\", \"Eastern\", \"CONNECTICUT\", \"Eastern\", \r\n\"DE\", \"Eastern\", \"DELAWARE\", \"Eastern\", \r\n\"DC\", \"Eastern\", \"DISTRICT OF COLUMBIA\", \"Eastern\", \r\n\"DC\", \"Eastern\", \"WASHINGTON DC\", \"Eastern\", \r\n\"FL\", \"Eastern\", \"FLORIDA\", \"Eastern\", \r\n\"GA\", \"Eastern\", \"GEORGIA\", \"Eastern\", \r\n\"HI\", \"Hawaii\", \"HAWAII\", \"Hawaii\", \r\n\"ID\", \"Pacific\", \"IDAHO\", \"Pacific\", \r\n\"IL\", \"Central\", \"ILLINOIS\", \"Central\", \r\n\"IN\", \"Eastern\", \"INDIANA\", \"Eastern\", \r\n\"IA\", \"Central\", \"IOWA\", \"Central\", \r\n\"KS\", \"Central\", \"KANSAS\", \"Central\", \r\n\"KY\", \"Eastern\", \"KENTUCKY\", \"Eastern\", \r\n\"LA\", \"Central\", \"LOUISIANA\", \"Central\", \r\n\"ME\", \"Eastern\", \"MAINE\", \"Eastern\", \r\n\"MD\", \"Eastern\", \"MARYLAND\", \"Eastern\", \r\n\"MA\", \"Eastern\", \"MASSACHUSETTS\", \"Eastern\", \r\n\"MI\", \"Eastern\", \"MICHIGAN\", \"Eastern\", \r\n\"MN\", \"Central\", \"MINNESOTA\", \"Central\", \r\n\"MS\", \"Central\", \"MISSISSIPPI\", \"Central\", \r\n\"MO\", \"Central\", \"MISSOURI\", \"Central\", \r\n\"MT\", \"Mountain\", \"MONTANA\", \"Mountain\", \r\n\"NE\", \"Central\", \"NEBRASKA\", \"Central\", \r\n\"NV\", \"Pacific\", \"NEVADA\", \"Pacific\", \r\n\"NH\", \"Eastern\", \"NEW HAMPSHIRE\", \"Eastern\", \r\n\"NJ\", \"Eastern\", \"NEW JERSEY\", \"Eastern\", \r\n\"NM\", \"Mountain\", \"NEW MEXICO\", \"Mountain\", \r\n\"NY\", \"Eastern\", \"NEW YORK\", \"Eastern\", \r\n\"NC\", \"Eastern\", \"NORTH CAROLINA\", \"Eastern\", \r\n\"ND\", \"Central\", \"NORTH DAKOTA\", \"Central\", \r\n\"OH\", \"Eastern\", \"OHIO\", \"Eastern\", \r\n\"OK\", \"Central\", \"OKLAHOMA\", \"Central\", \r\n\"OR\", \"Pacific\", \"OREGON\", \"Pacific\", \r\n\"PA\", \"Eastern\", \"PENNSYLVANIA\", \"Eastern\", \r\n\"PR\", \"DT\", \"PUERTO RICO\", \"DT\", \r\n\"RI\", \"Eastern\", \"RHODE ISLAND\", \"Eastern\", \r\n\"SC\", \"Eastern\", \"SOUTH CAROLINA\", \"Eastern\", \r\n\"SD\", \"Central\", \"SOUTH DAKOTA\", \"Central\", \r\n\"TN\", \"Eastern\", \"TENNESSEE\", \"Eastern\", \r\n\"TX\", \"Central\", \"TEXAS\", \"Central\", \r\n\"UT\", \"Mountain\", \"UTAH\", \"Mountain\", \r\n\"VT\", \"Eastern\", \"VERMONT\", \"Eastern\", \r\n\"VA\", \"Eastern\", \"VIRGINIA\", \"Eastern\", \r\n\"WA\", \"Pacific\", \"WASHINGTON\", \"Pacific\", \r\n\"WV\", \"Eastern\", \"WEST VIRGINIA\", \"Eastern\", \r\n\"WI\", \"Central\", \"WISCONSIN\", \"Central\", \r\n\"WY\", \"Mountain\", \"WYOMING\", \"Mountain\", \r\n\"AB\",\"Mountain\",\"ALBERTA\",\"Mountain\",\r\n\"BC\",\"Pacific\",\"BRITISH COLUMBIA\",\"Pacific\",\r\n\"MB\",\"Central\",\"MANITOBA\",\"Central\",\r\n\"NB\",\"Eastern\",\"NEW BRUNSWICK\",\"Eastern\",\r\n\"NL\",\"Newfoundland\",\"NEWFOUNDLAND AND LABRADOR\",\"Newfoundland\",\r\n\"NT\",\"Mountain\",\"NORTHWEST TERRITORIES\",\"Mountain\",\r\n\"NS\",\"Atlantic\",\"NOVA SCOTIA\",\"Atlantic\",\r\n\"NU\",\"Eastern\",\"NUNAVUT\",\"Eastern\",\r\n\"ON\",\"Eastern\",\"ONTARIO\",\"Eastern\",\r\n\"PE\",\"Newfoundland\",\"PRINCE EDWARD ISLAND\",\"Newfoundland\",\r\n\"QC\",\"Eastern\",\"QUEBEC\",\"Eastern\",\r\n\"SK\",\"Central\",\"SASKATCHEWAN\",\"Central\",\r\n\"YT\",\"Pacific\",\"YUKON\",\"Pacific\",\"Unknown\")"
            },
            {
              "name": "# of Contacts",
              "type": "NM",
              "summary": {
                "aggregation": "count",
                "childForeignKeyField": "Related Company",
                "childTable": "Contacts"
              }
            },
            {
              "name": "# of Activities",
              "type": "NM",
              "summary": {
                "aggregation": "sum",
                "childField": "# of Activities",
                "childForeignKeyField": "Related Company",
                "childTable": "Contacts"
              }
            },
            {
              "name": "Most Recent Activity Date",
              "type": "DT",
              "summary": {
                "aggregation": "maximum",
                "childField": "Most Recent Activity Date",
                "childForeignKeyField": "Related Company",
                "childTable": "Contacts"
              }
            }
          ]
        },
        {
          "name": "Contacts",
          "recordNoun": "Contact",
          "fields": [
            {
              "name": "Contact Full Name",
              "type": "TX",
              "formula": "[First Name]&\" \"&[Last Name]"
            },
            {
              "name": "Title / Job Function",
              "type": "TX"
            },
            {
              "name": "Phone",
              "type": "PH"
            },
            {
              "name": "Fax",
              "type": "PH"
            },
            {
              "name": "Mobile",
              "type": "PH"
            },
            {
              "name": "Email",
              "type": "EM"
            },
            {
              "name": "Address",
              "type": "LD"
            },
            {
              "name": "Different Contact Address?",
              "type": "CB"
            },
            {
              "name": "First Name",
              "type": "TX"
            },
            {
              "name": "Last Name",
              "type": "TX"
            },
            {
              "name": "Related Company",
              "type": "FK",
              "parent": "Companies",
              "proxyDisplayField": "Company Name"
            },
            {
              "name": "Company Name",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Company",
                "parentTable": "Companies",
                "parentField": "Company Name"
              }
            },
            {
              "name": "Company Phone",
              "type": "PH",
              "lookup": {
                "foreignKeyField": "Related Company",
                "parentTable": "Companies",
                "parentField": "Phone"
              }
            },
            {
              "name": "Company State",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Company",
                "parentTable": "Companies",
                "parentField": "State/Region"
              }
            },
            {
              "name": "Company Website",
              "type": "LK",
              "lookup": {
                "foreignKeyField": "Related Company",
                "parentTable": "Companies",
                "parentField": "Web"
              }
            },
            {
              "name": "Assigned Rep",
              "type": "US",
              "lookup": {
                "foreignKeyField": "Related Company",
                "parentTable": "Companies",
                "parentField": "Assigned To"
              }
            },
            {
              "name": "Company - Address",
              "type": "AD",
              "lookup": {
                "foreignKeyField": "Related Company",
                "parentTable": "Companies",
                "parentField": "Address"
              }
            },
            {
              "name": "Most Recent Activity Date",
              "type": "DT",
              "summary": {
                "aggregation": "maximum",
                "childField": "Activity Date",
                "filterCriteria": [
                  {
                    "field": "Activity Type",
                    "operator": "does_not_equal",
                    "value": "Schedule"
                  }
                ],
                "filterCriteriaLogicalOperator": "and",
                "childForeignKeyField": "Related Contact",
                "childTable": "Activities"
              }
            },
            {
              "name": "# of Activities",
              "type": "NM",
              "summary": {
                "aggregation": "count",
                "childForeignKeyField": "Related Contact",
                "childTable": "Activities"
              }
            }
          ]
        },
        {
          "name": "Activities",
          "recordNoun": "Activity",
          "fields": [
            {
              "name": "Activity Type",
              "type": "TC",
              "choices": [
                "Outbound Phone Call",
                "Inbound Phone Call",
                "Left Voicemail",
                "Email Sent",
                "Email Received",
                "Live Meeting Notes",
                "Schedule",
                "Research",
                "Just Notes"
              ]
            },
            {
              "name": "Activity Date",
              "type": "DT"
            },
            {
              "name": "Duration (mins)",
              "type": "DU"
            },
            {
              "name": "Created By",
              "type": "US"
            },
            {
              "name": "Notes",
              "type": "LD"
            },
            {
              "name": "Activity",
              "type": "TX",
              "formula": "[Contact Full Name]&\": \"&[Activity Date]&\" - \"&[Activity Type]"
            },
            {
              "name": "iCalendar Notes",
              "type": "TX",
              "formula": "If([Activity Type]=\"Schedule\",\"\\n\"&\"Scheduled Activity with: \"&[Scheduled For]&\"\\n\"&\r\n\"Scheduled for: \"&[Activity Date]&\" at \"&[Scheduled Start Time]&\" until \"&[Scheduled End Time]&\".\"&\"\\n\"&\"\\n\"&\r\n\"Contact Info: \"&\"\\n\"&\r\n\"Phone: \"&[Customer Phone]&\"\\n\"&\r\n\"Email: \"&[Customer Email]&\"\\n\"&\"\\n\"&\r\n\"------------------------------------------------------------------------\"&\"\\n\"\r\n&\"Notes:\"&\"\\n\"&\"\\n\"&\r\n[Notes],\"\")"
            },
            {
              "name": "Meeting Info / Location",
              "type": "TX"
            },
            {
              "name": "Related Company",
              "type": "NM"
            },
            {
              "name": "Related Contact",
              "type": "FK",
              "parent": "Contacts",
              "proxyDisplayField": "Contact Full Name"
            },
            {
              "name": "Schedule Status",
              "type": "TC",
              "choices": [
                "Scheduled",
                "Completed",
                "Cancelled",
                "Rep Missed",
                "Prospect Missed"
              ]
            },
            {
              "name": "Scheduled Activity Date",
              "type": "DT"
            },
            {
              "name": "Scheduled Activity Subject",
              "type": "TX"
            },
            {
              "name": "Scheduled End Date / Time",
              "type": "TM",
              "formula": "ToTimestamp([Scheduled Activity Date], [Scheduled End Time])"
            },
            {
              "name": "Scheduled End Time",
              "type": "TD",
              "formula": "[Scheduled Start Time]+[Duration (mins)]"
            },
            {
              "name": "Scheduled For",
              "type": "US"
            },
            {
              "name": "Scheduled Start Date / Time",
              "type": "TM",
              "formula": "ToTimestamp([Scheduled Activity Date], [Scheduled Start Time])"
            },
            {
              "name": "Scheduled Start Time",
              "type": "TD"
            },
            {
              "name": "Attempt Successful?",
              "type": "CB"
            },
            {
              "name": "Contact Full Name",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Contact",
                "parentTable": "Contacts",
                "parentField": "Contact Full Name"
              }
            },
            {
              "name": "Company Name",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Contact",
                "parentTable": "Contacts",
                "parentField": "Company Name"
              }
            },
            {
              "name": "Contact - Email",
              "type": "EM",
              "lookup": {
                "foreignKeyField": "Related Contact",
                "parentTable": "Contacts",
                "parentField": "Email"
              }
            },
            {
              "name": "Contact - Mobile",
              "type": "PH",
              "lookup": {
                "foreignKeyField": "Related Contact",
                "parentTable": "Contacts",
                "parentField": "Mobile"
              }
            },
            {
              "name": "Contact - Phone",
              "type": "PH",
              "lookup": {
                "foreignKeyField": "Related Contact",
                "parentTable": "Contacts",
                "parentField": "Phone"
              }
            },
            {
              "name": "Contact - Address",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Contact",
                "parentTable": "Contacts",
                "parentField": "Address"
              }
            }
          ]
        }
      ]
    },
    "search_value": "Companies (Company Name, Address, Web, Phone, Industry, Lead Status, Lead Source, Assigned To, Fax, Time Zone, # of Contacts, # of Activities, Most Recent Activity Date), Contacts (Contact Full Name, Title / Job Function, Phone, Fax, Mobile, Email, Address, Different Contact Address?, First Name, Last Name, Company Name, Company Phone, Company State, Company Website, Assigned Rep, Company - Address, Most Recent Activity Date, # of Activities), Activities (Activity Type, Activity Date, Duration (mins), Created By, Notes, Activity, iCalendar Notes, Meeting Info / Location, Related Company, Schedule Status, Scheduled Activity Date, Scheduled Activity Subject, Scheduled End Date / Time, Scheduled End Time, Scheduled For, Scheduled Start Date / Time, Scheduled Start Time, Attempt Successful?, Contact Full Name, Company Name)",
  },
  "AppID2": {
    "ai_dict": {
      "name": "Inventory App",
      "description": "",
      "tables": [
        {
          "name": "Projects",
          "recordNoun": "Project",
          "fields": [
            {
              "name": "Project Name",
              "type": "TX"
            },
            {
              "name": "Project Manager",
              "type": "US"
            },
            {
              "name": "Priority",
              "type": "TC",
              "choices": [
                "High",
                "Medium",
                "Low"
              ]
            },
            {
              "name": "Status",
              "type": "TC",
              "choices": [
                "In-Progress",
                "On Hold"
              ]
            },
            {
              "name": "Description",
              "type": "TX"
            },
            {
              "name": "Start Date",
              "type": "DT"
            },
            {
              "name": "End Date",
              "type": "DT"
            },
            {
              "name": "Est End Date",
              "type": "DT"
            },
            {
              "name": "Est Start Date",
              "type": "DT"
            },
            {
              "name": "Total Cost of Inventory",
              "type": "CA",
              "summary": {
                "aggregation": "sum",
                "childField": "Cost of Inventory",
                "childForeignKeyField": "Related Project",
                "childTable": "Inventory Usage"
              }
            }
          ]
        },
        {
          "name": "Inventory",
          "recordNoun": "Inventory",
          "fields": [
            {
              "name": "SKU",
              "type": "TX"
            },
            {
              "name": "Product Name",
              "type": "TX"
            },
            {
              "name": "Product Type",
              "type": "TC",
              "choices": [
                "Sprockets",
                "Widgets"
              ]
            },
            {
              "name": "Product Description",
              "type": "LD"
            },
            {
              "name": "Shipping Weight (lbs.)",
              "type": "NM"
            },
            {
              "name": "Avg Inventory Cost",
              "type": "CA",
              "formula": "[Total Cost Added]/[Total Quantity Added]"
            },
            {
              "name": "Total Quantity Added",
              "type": "NM",
              "summary": {
                "aggregation": "sum",
                "childField": "Quantity",
                "filterCriteria": [
                  {
                    "field": "Purchase Order - Status",
                    "operator": "equals",
                    "value": "Completed"
                  }
                ],
                "filterCriteriaLogicalOperator": "and",
                "childForeignKeyField": "Related Inventory",
                "childTable": "Purchase Order Line Items"
              }
            },
            {
              "name": "Total Quantity In Transit",
              "type": "NM",
              "summary": {
                "aggregation": "sum",
                "childField": "Quantity",
                "filterCriteria": [
                  {
                    "field": "Purchase Order - Status",
                    "operator": "equals",
                    "value": "Shipped"
                  }
                ],
                "filterCriteriaLogicalOperator": "and",
                "childForeignKeyField": "Related Inventory",
                "childTable": "Purchase Order Line Items"
              }
            },
            {
              "name": "Total Cost Added",
              "type": "CA",
              "summary": {
                "aggregation": "sum",
                "childField": "Cost",
                "filterCriteria": [
                  {
                    "field": "Purchase Order - Status",
                    "operator": "equals",
                    "value": "Completed"
                  }
                ],
                "filterCriteriaLogicalOperator": "and",
                "childForeignKeyField": "Related Inventory",
                "childTable": "Purchase Order Line Items"
              }
            },
            {
              "name": "Total Cost In Transit",
              "type": "CA",
              "summary": {
                "aggregation": "sum",
                "childField": "Cost",
                "filterCriteria": [
                  {
                    "field": "Purchase Order - Status",
                    "operator": "equals",
                    "value": "Shipped"
                  }
                ],
                "filterCriteriaLogicalOperator": "and",
                "childForeignKeyField": "Related Inventory",
                "childTable": "Purchase Order Line Items"
              }
            },
            {
              "name": "Total Quantity Used",
              "type": "NM",
              "summary": {
                "aggregation": "sum",
                "childField": "Quantity",
                "childForeignKeyField": "Related Inventory",
                "childTable": "Inventory Usage"
              }
            },
            {
              "name": "Total Cost of Inventory Used",
              "type": "CA",
              "summary": {
                "aggregation": "sum",
                "childField": "Cost of Inventory",
                "childForeignKeyField": "Related Inventory",
                "childTable": "Inventory Usage"
              }
            }
          ]
        },
        {
          "name": "Purchase Orders",
          "recordNoun": "Purchase Order",
          "fields": [
            {
              "name": "Vendor",
              "type": "TX"
            },
            {
              "name": "Status",
              "type": "TC",
              "choices": [
                "Pending",
                "Submitted",
                "Shipped",
                "Completed",
                "Cancelled"
              ]
            },
            {
              "name": "Order Date",
              "type": "DT"
            },
            {
              "name": "Arrival Date",
              "type": "DT"
            },
            {
              "name": "Total Cost",
              "type": "CA",
              "summary": {
                "aggregation": "sum",
                "childField": "Cost",
                "childForeignKeyField": "Related Purchase Order",
                "childTable": "Purchase Order Line Items"
              }
            }
          ]
        },
        {
          "name": "Purchase Order Line Items",
          "recordNoun": "Purchase Order Line Item",
          "fields": [
            {
              "name": "Related Purchase Order",
              "type": "FK",
              "parent": "Purchase Orders"
            },
            {
              "name": "Quantity",
              "type": "NM"
            },
            {
              "name": "Price/Unit",
              "type": "CA"
            },
            {
              "name": "Cost",
              "type": "CA",
              "formula": "[Quantity]*[Price/Unit]"
            },
            {
              "name": "Related Inventory",
              "type": "FK",
              "parent": "Inventory",
              "proxyDisplayField": "Inventory - SKU"
            },
            {
              "name": "Purchase Order - Vendor",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Purchase Order",
                "parentTable": "Purchase Orders",
                "parentField": "Vendor"
              }
            },
            {
              "name": "Purchase Order - Status",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Purchase Order",
                "parentTable": "Purchase Orders",
                "parentField": "Status"
              }
            },
            {
              "name": "Inventory - SKU",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "SKU"
              }
            },
            {
              "name": "Inventory - Product Name",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "Product Name"
              }
            },
            {
              "name": "Inventory - Product Description",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "Product Description"
              }
            }
          ]
        },
        {
          "name": "Inventory Usage",
          "recordNoun": "Inventory Usage",
          "fields": [
            {
              "name": "Quantity",
              "type": "NM"
            },
            {
              "name": "Cost of Inventory",
              "type": "CA",
              "formula": "[Quantity] * [Avg Inventory Cost]"
            },
            {
              "name": "Related Inventory",
              "type": "FK",
              "parent": "Inventory",
              "proxyDisplayField": "Inventory - SKU"
            },
            {
              "name": "Related Project",
              "type": "FK",
              "parent": "Projects",
              "proxyDisplayField": "Project Name"
            },
            {
              "name": "Project Name",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Project",
                "parentTable": "Projects",
                "parentField": "Project Name"
              }
            },
            {
              "name": "Inventory - SKU",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "SKU"
              }
            },
            {
              "name": "Inventory - Product Name",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "Product Name"
              }
            },
            {
              "name": "Inventory - Product Description",
              "type": "TX",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "Product Description"
              }
            },
            {
              "name": "Avg Inventory Cost",
              "type": "CA",
              "lookup": {
                "foreignKeyField": "Related Inventory",
                "parentTable": "Inventory",
                "parentField": "Avg Inventory Cost"
              }
            }
          ]
        }
      ]
    },
    "search_value": "Projects (Project Name, Project Manager, Priority, Status, Description, Start Date, End Date, Est End Date, Est Start Date, Total Cost of Inventory), Inventory (SKU, Product Name, Product Type, Product Description, Shipping Weight (lbs.), Avg Inventory Cost, Total Quantity Added, Total Quantity In Transit, Total Cost Added, Total Cost In Transit, Total Quantity Used, Total Cost of Inventory Used), Purchase Orders (Vendor, Status, Order Date, Arrival Date, Total Cost), Purchase Order Line Items (Quantity, Price/Unit, Cost, Purchase Order - Vendor, Purchase Order - Status, Inventory - SKU, Inventory - Product Name, Inventory - Product Description), Inventory Usage (Quantity, Cost of Inventory, Project Name, Inventory - SKU, Inventory - Product Name, Inventory - Product Description, Avg Inventory Cost)",
  }
}
```
