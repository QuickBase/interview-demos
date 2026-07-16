# Tenant-Aware Job Scheduler

This exercise gives us shared context for discussing your code, your design choices, and your tradeoffs.

Plan on **6–8 hours** of focused time. There is no hard limit. We look at how clearly you build and explain your work, not how much you finish. A small, well-built solution scores well.

## General Description

Build a small service - similar to a workflow engine - that accepts jobs from multiple tenants and runs them against shared downstream targets, and must not let one tenant (or one downstream target) starve everyone else.

## The Scenario

- `POST /jobs` - enqueue a job `{ tenantId, targetId, payload, idempotencyKey }`. Same idempotency key must not double-enqueue or double-run, even under concurrent duplicate requests.
- A scheduler/worker loop that runs pending jobs subject to three concurrency caps simultaneously:
  - Global max concurrent jobs
  - Max concurrent jobs per tenant
  - Max concurrent jobs per target (simulate a slow/limited downstream)
- Job lifecycle: `pending → running → succeeded | failed`, with a bounded number of retries on failure.
- `GET /jobs/stream` - SSE (or WS) endpoint pushing live status updates.
- A minimal React UI: a form to enqueue jobs, a live list of jobs with status, and a visible indicator when a job is queued specifically because a concurrency cap is hit (not just "pending").

## Non-Goals / Optional

- A real auth/authz system is not required. A fake `tenantId` header is a fine stand-in for real auth.
- Real downstream integration is not required. Target execution can be a fake async call with configurable latency/failure rate.
- No specific infra/deployment requirement. The reasoning behind your choice matters more than which one you pick.
- Persistence surviving a process restart is optional. If you skip it, call it out as a tradeoff rather than building it.

## On AI Tools

Use AI coding assistants if that is part of how you normally work - we do too. Come to the live discussion ready to explain and defend every design decision, regardless of how the code got written.

## Deliverables

1. Working code, runnable with a single command.
2. Tests specifically covering the concurrency-critical paths (duplicate idempotency key under race, cap enforcement under burst load).
3. A README - setup, architecture. A general guide: it helps to explain why you chose your concurrency-control mechanism, what you would improve with more time.

## What we will discuss

During the demo we will go through your solution at a high level:

1. A quick run-through of your system's design.
2. Code walkthrough.
3. Review of the design choices and tradeoffs you made.
4. How you would extend it if you had more time.
5. And, if applicable, how you used AI.