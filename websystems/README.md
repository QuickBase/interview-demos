# Quickbase Web Systems - Senior Manager Front End Craft Demo

## General Description

While hands-on coding may not be the core responsibility of this role, it is essential that the candidate demonstrates strong **technical leadership**, **architectural thinking**, and the ability to effectively collaborate across **design, engineering, and product teams**.

The goal is to understand how you would **plan, architect, and guide the development** of a new content listing page based on provided designs and dataset.

**Use of your favorite libraries or frameworks is welcomed. The requirements outlined below can be completed with or without a framework. We like using frameworks to help us deliver customer value faster, but be careful that you can still demonstrate your coding ability.**

Your demo should run on whichever web browser you prefer.

**Expected Time Commitment:** 3-4 hours.

**Figma Link:** [Design Mockups](https://www.figma.com/design/9gs04bvF5dkx46uR4YPe4v/Ad-Hoc?node-id=2111-18&t=oBufkT96iL7cwii4-1)

---

## Candidate Exercise Presentation Outline

When you show off your craft demo, we will ask you to show us how it works from a visitor's perspective looking at the finished site. After that, we will ask for a tour of your code with a focus on how you got the core functionality to work, and how you would lead a team through this type of work.

---

# Core Requirements

## Planning

- **Component Breakdown:** What reusable components would you create (cards, links, pills, filters, pagination, etc.)?
- **Layout & Responsiveness:** What layout techniques would you use (grid, flexbox, etc.)?
- **Data Handling:** How do you propose to fetch, filter, search, and paginate the data?
- **Maintainability:** Folder structure, SCSS usage, BEM and naming conventions.
- **Collaboration:** When and how you would check in with **design, content, and engineering** to validate the implementation.
- **Challenges & Tradeoffs:** What risks or ambiguities do you foresee?

---

## Coding Requirements

### Recreate the provided mockups
- Your code should match the provided [mobile](https://github.com/QuickBase/interview-demos/blob/5d9820ccc70223a638e843057588769d2511fdca/websystems/Web-Systems__Craft-Demo-Mockup--Mobile.jpg) and [desktop](https://github.com/QuickBase/interview-demos/blob/5d9820ccc70223a638e843057588769d2511fdca/websystems/Web-Systems__Craft-Demo-Mockup--Desktop.jpg) mockups.

### Responsive Design
- Ensure the design works well across mobile and desktop.

### Reusable Components
- Create a **reusable card component** that dynamically renders based on the provided JSON data.
- Create a **reusable link component** that can be inserted into each card.
- Create a **reusable pill component** for the category, placed between the image and title.

### Card Generation
- For each object in the provided JSON array:
    - Use the reusable card component to generate the cards dynamically.
    - If an object doesn’t have an image, do not create a card for that object.
    - If an object doesn’t have a link URL, do not show the link, but still display the card with the other content.

### Default Title
- If a card does not have a title property or it is empty, use **"National Park"** as the default title.

### Featured Card
- One card will be marked as **"featured"** and should:
    - Appear first in the card list.
    - The **Category** pill should stand out visually (you can decide how).
    - Have a link with a **Chrome background and black text**.

### Category Pill Styling & Behavior
- The reusable category pill component should have proper styling and hover effects using the updated colors:
    - Background: **Gin**
    - Text: **Black**

### Consistent Card Height
- Ensure all cards in a row maintain the same height, regardless of content length.
- The link should always align at the bottom even if there is extra space between the text and link.

### Filtering & Search
- Implement a filter that allows users to filter by **category**.
    - Based on the mockups all **categories** should be listed below the search input as clickable items that will dynamically filter the cards.
- Implement a search input field that allows users to search cards by **title**.
- Filters and search should work together to dynamically refine the results.
- Use **Dove Gray** for the search placeholder and text.

---

## Live Discussion (During Interview)

During your interview, we will ask you to walk us through your approach and your code sample. Be prepared to discuss:

- Your technical decisions and tradeoffs.
- How you would mentor or guide junior engineers in building this page.
- How you would adapt if the design evolved during development.
- How you would track progress across your team.

---

# Bonus Points

- Add a note on **tracking analytics** for filter and pagination usage.
- Suggest how this could be wired up to a **CMS for future flexibility**.
- Describe how you would enforce **design system consistency** across similar pages (shared tokens, components, or stylesheets).
- Add Pagination
    - Implement pagination to limit the number of cards displayed per page.
    - The number of cards per page is up to your discretion.
    - Users should be able to navigate between pages.

---

# Final Note

We know this is a lot of information, but remember: **we are more interested in your leadership and technical thought process than seeing a perfect build.** Focus on showing us how you would approach solving this problem with a **team-first mindset**.
