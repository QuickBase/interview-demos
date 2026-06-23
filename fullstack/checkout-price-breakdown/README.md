# Checkout Price Breakdown — Full Stack Craft Demo

## General Description

This exercise gives us shared context for discussing your code, your design choices, and your tradeoffs.

Plan on **3–4 hours** of focused time. There's no hard limit. We look at how clearly you build and explain your work, not how much you finish. A small, well-built solution scores well.

This is a **full-stack** exercise: build a small backend/API and a small UI that calls it. The receipt is computed on the server, not in the browser. Otherwise:

- Use any stack — the frontend can be plain JS, and the backend can be minimal.
- In-memory storage is fine — no database, no external services, and no external accounts.
- Keep the UI plain: minimal styling is fine, up/down buttons are plenty for reordering, and don't use a ready-made pricing/tax library, a drag-and-drop library, or a pricing/rules engine to do the core math.

## AI use

You may use AI tools. AI use is optional and will not count for or against you. We care that you understand and can explain the work you submit.

## The Scenario

A small pricing feature. Given a cart and a catalog of pricing rules (discounts plus server-applied tax), the user composes an ordered stack of active rules, and the server computes an itemized receipt. The order of the rules changes the result. Stacks can be saved by name and re-run.

It's more than adding up a cart. The interesting part is how you model the pricing: the server does the math, the order of the rules changes the total, the money stays exact to the cent, and a saved stack re-runs against current prices.

## What's provided

**`data/cart.json`** (the line items) and **`data/rules.json`** (the rule catalog), plus this brief. **There's no scaffold** — you design the data model, the API, and the UI.

The input is a set of rules to compose, not a form to fill in: the candidate selects, orders, and toggles rules from the server's catalog. Don't build a UI for authoring new rules; just compose the ones provided.

## The data

A line item: `{ "sku": "SKU-A", "name": "Widget", "unitPriceCents": 1000, "qty": 3 }`. Money is **integer cents**.

A rule: `{ "key": "r_pct10", "label": "10% off order", "type": "percentOff", "params": { "percent": 10 } }`. Rule **types** in the catalog: **percentOff**, **fixedOff**, **thresholdOff** (applies only if the running subtotal at that point in the stack is ≥ a minimum), **lineItemPercentOff** (one SKU), and a **server-only `tax`** rule (`"serverOnly": true`) that **adds** to the running subtotal — the only rule that raises the total, so the discount cap doesn't apply to it.

### The engine

- The client sends an **ordered list of active rule keys** (and a **cart id**, if you model more than one cart) — never the prices, a formula, expression, or amount. **The server owns the cart and the catalog** (the sample is a single cart), so a saved stack recomputes from the server's current cart/prices. Reject unknown rule keys and any client-supplied amount or formula instead of a key. If a request includes prices or a modified cart, ignore or reject them; compute from the server's cart. The ordered client list should contain each client-composable rule at most once; duplicate client rule keys should be rejected.
- The server applies the active rules in order to the running subtotal, then always applies server-only rules last (tax), and returns an itemized receipt: each cart line, then each adjustment in order, showing the rule that caused it and the running subtotal after it. The total reads top to bottom. If the client includes a server-only rule key, the server should ignore it in the client stack and still apply the server-only rule exactly once at the end.
- A line-item discount is computed from the target line's server-owned cart total, not a total that earlier order-level discounts already reduced. The result is then subtracted from the running subtotal.
- Discount rules are capped at the current running subtotal, so discounts do not make the subtotal negative. A line-item discount whose SKU is not in the server-owned cart records an adjustment that does nothing.
- **Order matters:** a percentage applied before vs after a fixed discount yields different totals.
- **Money is exact:** integer cents end to end. When a rule produces a fractional-cent adjustment, round the **adjustment amount** half-up to integer cents before applying it to the running subtotal. For example, 10% of the sample cart's 8805-cent subtotal is 880.5, which rounds half-up to **881**.

## Core Requirements (the MVP)

1. **Show the cart and the rule catalog** (from the server).
2. **Compose an ordered, toggleable stack** of active rules; the UI asks the **server** to recompute an itemized receipt as the stack changes.
3. **Order is respected** — applying the rules in a different order changes the total.
4. **Money:** follow the integer-cent and half-up rounding rules in the engine section.
5. **The server owns the catalog and computation.** The client sends **keys + order**, never prices, formulas, amounts, or computed totals.
6. **Save a stack by name** and **load** it — a saved stack stores the **definition (keys + order), not the computed receipt** — so re-running reflects the **current** cart/prices. In-memory saved stacks are fine for the MVP; they only need to survive for the lifetime of the running server process. Saving an existing stack name replaces that saved definition. A saved stack can also be deleted; after deletion, it should no longer appear in the saved-stack list or be loadable.
7. **An API you design**, with a consistent error shape.
8. **A short `NOTES.md`** — how to run it, your main choices and tradeoffs, and what you tested.

## Stretch (optional)

Pick one or two if time allows. Not required.

- **Per-line attribution:** show which rule changed which line.
- **Durable saved stacks:** persist stack definitions across server restarts.
- **A permission-aware rule** only some users may apply — the server enforces who's allowed to use it.
- **Conflicting-rule handling** (e.g., two discounts on one SKU) with a documented policy.
- **Add a new rule type** — for example a **shipping fee** or **free shipping over a threshold**. On the call, we may ask you to add one live.

## Submitting your work

- **The project** — a GitHub repo or a runnable archive (a zip), with run steps in `NOTES.md`.
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

**Can this be frontend-only or backend-only?** No. This is a full-stack exercise: build a small UI and a small backend/API. The UI must call the backend/API for receipts.

**Real auth / login?** Not required. A user picker, request header, or query parameter is fine.

**Didn't finish?** Note what you would do next in `NOTES.md`.

**Disagree with a rule or the API shape?** That is acceptable; implement it as you prefer and explain your reasoning in `NOTES.md`.
