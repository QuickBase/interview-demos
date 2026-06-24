# Expense Requests — Full Stack Craft Demo

## General Description

This exercise gives us shared context for discussing your code, your design choices, and your tradeoffs.

Plan on **3–4 hours** of focused time. There's no hard limit. We look at how clearly you build and explain your work, not how much you finish. A small, well-built solution scores well.

Use any stack — any frontend (or plain JS) and any backend you like. In-memory storage is fine (no database needed), and no external services or accounts are needed. A simple list/detail/form UI is expected (a data-grid library isn't necessary), and please don't use a ready-made form builder or workflow engine that implements the core form or approval behavior for you.

Keep the UI simple — minimal styling is fine.

## AI use

You may use AI tools. AI use is optional and will not count for or against you. We care that you understand and can explain the work you submit.

## The Scenario

An internal tool for **expense requests**. Anyone can create and submit their own request. Some people are managers or finance approvers who approve or reject requests submitted by others. The form is conditional — some fields appear or become required based on others — and each request runs through an approval workflow, with the server deciding who approves it.

Sample users and a few existing requests are provided in `data/` (`users.json`, `requests.json`). These are starter records; your app may create more as it runs.

## Core Requirements

Build all of these, but keep the implementation lean — a tight, correct slice is the goal, not breadth or polish; the full set should fit the 3–4 hours.

1. **The form.** Create and edit a request. Some fields appear or become required based on the others:

   | Field | Type | Rule |
   |---|---|---|
   | Expense type | dropdown (Travel / Software / Equipment / Meal / Other) | required |
   | Amount | money (whole cents — $12.50 is `1250`) | required, can't be negative |
   | Description | text | required |
   | Billable to a client? | checkbox | — |
   | Client | dropdown | appears, and is required, once "Billable" is checked |
   | Extra justification | text | appears, and is required, once the amount is $1,000 or more |
   | Other reason | text | appears, and is required, when Expense type is "Other" |

   The set of clients is up to you — a short hardcoded list is fine (include `Acme`, which the seed data uses).

2. **Drafts and submitting.** A request starts as a **Draft** and can be saved incomplete; the rules only have to pass on **submit**. Only the request's owner — the requester — can edit or submit it. Once submitted it can't be edited; once approved or rejected it's final for the core requirements. If you choose the optional resubmit stretch, a **Rejected** request may be reopened only through that owner-only fix-and-resubmit flow.

3. **Routing (decided on the server).** When a valid request is submitted, the server picks the approver: under $1,000 → the requester's **manager**; $1,000 or more → **finance**; never the requester — if the manager is missing or the chosen approver would be the requester, it falls back to finance; if finance would also be the requester, submitting is refused with a clear error. (**Finance** is a user with `role: "finance"` — the sample has one; **manager** is the requester's `managerId`.)

4. **Approving.** Only the assigned approver can approve or reject a request.

5. **Enforce it on the server.** Validation, who's allowed to submit, edit, and approve, and the status all have to hold even if someone calls the API directly — not just in the browser. The client doesn't get to set the status, the requester, or the approver.

6. **List, detail, and history.** A list of requests and a detail view showing the history — who created, submitted, approved, or rejected it, and when. The status always matches the latest action. When a submit fails, the response says which fields are wrong so the UI can show it.

7. **A short** `NOTES.md` — how to run it, your main choices and tradeoffs, and what you tested.

You design the data model, the API, and the UI.

## Stretch (optional)

Take on whatever interests you, as time allows — none are required.

- More type-specific fields — e.g. Travel → destination and dates, or Software → vendor and a reason.
- A rejected request can be fixed and resubmitted by its owner. Resubmitting should re-validate, recompute the approver, add to history, and may include a note from the requester.
- Comments on an approval or rejection. Comments should appear in history; rejection comments should be visible to the requester while they are fixing and resubmitting.
- Search or filter the list.
- A read-only view for people who can't act on a request.
- A "why is this required?" explanation on a field.
- More than one approval step.

## Submitting your work

- **The project** — a GitHub repo with run steps in `NOTES.md`.
- **Your commit history** (if you share a repo) — commit as you go rather than squashing to a single commit. It isn't graded for tidiness.
- **If you used AI** — include your relevant prompts (an export, a gist, or a folder is fine), and in `NOTES.md` note what was AI-assisted and also mention if there were cases where you agreed or disagreed with the AI.

## What we will discuss

During the demo we'll go through your solution at a high level:

1. A quick run-through of your system's design.
2. Code walkthrough.
3. Review of the design choices and tradeoffs you made.
4. How you'd extend it if you had more time.
5. And, if applicable, how you used AI.

## FAQ

**Time limit?** There is no hard limit, but we do not expect it to take more than a few hours.

**Real auth / login?** Not required. A user picker, request header, or query parameter is fine.

**File uploads, receipts, notifications, tax, currency conversion?** Not required — but if any of these interest you, feel free to add one and mention it in `NOTES.md`.

**A validation library?** Using one is acceptable; the server must still enforce the rules.

**A data-grid library?** Not necessary — the focus is on the rules, the workflow, and the API. A simple list/detail/form UI is plenty, but a richer one is fine if you'd like.

**Didn't finish?** Note what you would do next in `NOTES.md`.

**Disagree with a rule or the API shape?** That is acceptable; implement it as you prefer and explain your reasoning in `NOTES.md`.
