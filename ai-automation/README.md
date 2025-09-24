# **AI Automation Craft Demo**

## **Purpose**
This exercise evaluates your ability to identify automation opportunities in everyday business workflows and implement intelligent solutions using AI. We're interested in how you approach problems and leverage AI to create practical automations. You can use automation platforms, no-code tools, or write code - whatever approach you're comfortable with.

## **Instructions**

### **Part 1: Solution Design (45-60 minutes)**
Review the 3 business scenarios below. Choose **1-2 scenarios** and for each one, provide:
1. **Simple workflow diagram** - Show the basic flow and components
2. **Design explanation** - How would you automate this? Where would you use AI vs. traditional logic?
3. **Key challenges** - What are the tricky parts and how would you handle them?

### **Part 2: Implementation (2-3 hours)**
Select **1 scenario** and build a working solution that demonstrates:
- Integration with an LLM for intelligent decision-making
- Basic workflow automation
- Handling of at least one edge case

**Suggested Tools:**
- **Automation Platforms**: n8n, Quickbase, or similar
- **AI Services**: OpenAI, Anthropic, Google AI, or any LLM API
- **Alternative**: If you prefer coding, that's fine too (any language)

## **Business Scenarios**

### **Scenario 1: The Support Ticket Organizer**
**The Problem:** 
The support team receives 50+ customer emails daily. These need to be sorted into the right categories and sent to the appropriate team. Currently, someone manually reads each email and forwards it, which takes 2 hours every morning.

**Categories to sort into:**
- Technical Issue (bugs, error messages)
- Billing (invoices, refunds, payments)
- Account Access (password reset, login problems)
- How-To Question (need help using features)
- Feature Request (asking for new functionality)
- Other (doesn't fit above)

**Example emails:**
- "I can't log into my account" → *Account Access*
- "How do I export my data?" → *How-To Question*
- "I was charged twice this month!" → *Billing*

**Your Challenge:** 
Build an automation that reads support emails and automatically categorizes them.

**Optional Bonus:** Also assign priority (Low/Medium/High) based on the customer's tone or urgency words.

---

### **Scenario 2: The Team Update Collector**
**The Problem:**
Every day, 10 team members are supposed to post what they're working on and if they're blocked. But updates come through different channels - some email, some Slack messages, some in a shared doc. The manager spends 45 minutes each morning trying to figure out who's blocked and who forgot to send an update.

**Example updates:**
- "Working on the new feature, need access to the test database"
- "Finished the bug fix, starting documentation today"
- "Out sick today"

**Your Challenge:**
Create an automation that:
- Collects all updates (you can simulate this with different input files)
- Identifies who didn't send an update
- Highlights anyone who's blocked
- Creates a simple summary for the manager

**Optional Bonus:** Detect if multiple people are working on the same thing.

---

### **Scenario 3: The Interview Scheduler**
**The Problem:**
When candidates apply for jobs, someone has to manually coordinate interviews. This means checking the candidate's availability, finding time when interviewers are free, sending calendar invites, and sending confirmation emails. For 20 candidates a week, this takes hours of back-and-forth emailing.

**The specific workflow:**
1. Candidate emails their availability (e.g., "I'm free Tuesday and Thursday afternoons")
2. Recruiter checks interviewer calendars
3. Recruiter sends calendar invites
4. Recruiter emails candidate with confirmation

**Your Challenge:**
Build an automation for ANY part of this process. For example, you could:
- Parse candidate emails to extract their availability
- Generate calendar invites based on availability
- Send automated confirmation emails
- Create a simple scheduling assistant

Pick whichever part seems most interesting or valuable to automate.

**Optional Bonus:** Handle timezone differences or conflicting schedules.

## **Requirements**

Your solution should include:

1. **AI/LLM Integration**
   - Use AI to handle the parts that need intelligence (understanding text, making decisions)
   - Can use any AI service or API

2. **Working Automation**
   - Takes input (files, forms, or mock data)
   - Processes it through your workflow
   - Produces useful output
   - Handles at least one edge case

3. **Brief Explanation**
   - How does your automation work?
   - What tools did you use and why?
   - What assumptions did you make?

## **Deliverables**

1. **Design Document(s)** - Your 1-2 scenario designs (simple diagrams or written explanation)
2. **Working Solution** - Implementation of 1 scenario using any tools/approach

## **Evaluation Criteria**

We'll look at:
1. **Problem Understanding** - Did you identify what really needs automation?
2. **Smart AI Use** - Using AI for the right things
3. **Practical Solution** - Would this actually save time?
4. **Clear Thinking** - Can we understand your approach?

## **Time Expectation**
- Part 1 (Design): 45-60 minutes
- Part 2 (Implementation): 2-3 hours
- Total: ~3-4 hours

You can spread this over 2-3 days.

## **Getting Started Tips**

- **Start simple** - Get basic automation working first
- **Use mock data** - We'll provide sample files, or make your own
- **Document assumptions** - If something is unclear, just note what you assumed
- **Partial solutions are fine** - Better to nail one part than rush everything

## **Sample Data**

We'll provide optional sample data:
- `support_emails.txt` - 20 example support emails
- `team_updates.txt` - Daily updates from team members
- `candidate_emails.txt` - Interview availability from candidates

---