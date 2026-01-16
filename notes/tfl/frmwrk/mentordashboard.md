# 🌼 TFLAssessment – Mentor Dashboard

> **Purpose:** Give mentors full control over assessments while AI works silently in the background as an assistant.

## 1️⃣ Mentor Dashboard – Home Overview

```
┌──────────────────────────────────────────────────────────┐
│ 🌼 Transflower Mentors | TFLAssessment Dashboard         │
├──────────────────────────────────────────────────────────┤
│ Mentor: Ravi Tambade    | Role: Lead Mentor              │
│ Active Cohorts: 3       | Learners: 86                   │
└──────────────────────────────────────────────────────────┘

┌───────────────┬───────────────┬───────────────┬──────────┐
│ Active Tests  │ Pending Review│ Skill Gaps    │ Alerts   │
│      6        │       12      │     18        │    3     │
└───────────────┴───────────────┴───────────────┴──────────┘

┌──────────────────────────────────────────────────────────┐
│ 📊 Skill Health Snapshot                                   
│ • Strong: Programming Basics                             │
│ • Average: Web Architecture                              │
│ • Weak: Dependency Injection, LINQ                       │
└──────────────────────────────────────────────────────────┘
```

## 2️⃣ Assessment Creation Flow (Mentor-Controlled)

```
┌──────────────── Create New Assessment ─────────────────────┐
│ Select TFL Layer:   [ Layer 1 ▼ ]                          │
│ Select Skills:      [ Programming Basics ✓ ]               │
│                     [ OOP Fundamentals ✓ ]                 │
│ Bloom Levels:       [ Remember ] [ Apply ✓ ] [ Analyze ]   │
│ Difficulty Mix:     Easy 30% | Medium 50% | Hard 20%       │
│ Duration:           60 Minutes                             │
│ Question Types:     MCQ ✓  Coding ✓  Scenario ✓           │
│                                                            │
│  [ Generate with AI ]   [ Save as Draft ]                  │
└────────────────────────────────────────────────────────────┘
```
## 3️⃣ AI-Generated Question Review Screen

```
┌──────────── AI Generated Questions (Draft) ──────────────┐
│ Q1. Explain how dependency injection improves            │
│      testability                                         │
│ Skill: DI | Bloom: Understand | Difficulty: Easy         │
│ [ Approve ] [ Edit ] [ Regenerate ]                      │
├──────────────────────────────────────────────────────────┤
│ Q2. Debug the following code snippet...                  │
│ Skill: LINQ | Bloom: Apply | Difficulty: Medium          │
│ [ Approve ] [ Edit ] [ Replace ]                         │
├──────────────────────────────────────────────────────────┤
│ Q3. Design a service lifetime strategy for...            │
│ Skill: DI | Bloom: Analyze | Difficulty: Hard            │
│ [ Approve ] [ Edit ] [ Remove ]                          │
└──────────────────────────────────────────────────────────┘

📌 *Mentor can edit wording, answers, difficulty or reject AI output.*
```
## 4️⃣ Assessment Publishing Screen

```
┌──────────────── Publish Assessment ──────────────────────┐
│ Assessment Name:   ASP.NET Core – Layer 3 Diagnostic     │
│ Assigned To:       Cohort B (Jan 2025)                   │
│ Start Date:        05 Jan 2025                           │
│ End Date:          07 Jan 2025                           │
│ Attempts Allowed:  1                                     │
│ Feedback Mode:    Immediate ✓ Mentor Review ✓           │ 
│                                                          │
│ [ Publish ]        [ Schedule ]        [ Cancel ]        │
└──────────────────────────────────────────────────────────┘
```

## 5️⃣ Learner Performance Analytics (Mentor View)

```
┌──────────────── Learner Skill Analytics ─────────────────┐
│ Learner: Ankit Sharma                                    │
│ Layer: 3 – System Understanding                          │
├──────────────────────────────────────────────────────────┤
│ Skill                Mastery     Status                  │
│ Programming Basics   85%         Strong                  │
│ MVC Flow             78%         Stable                  │
│ Dependency Injection 42%         ⚠ Needs Support         │
│ LINQ                 35%         ⚠ Weak                  │
├──────────────────────────────────────────────────────────┤
│ AI Insight:                                              │
│ • Conceptual clarity is good                             │
│ • Struggles with lifetime selection                      │
│ • Needs scenario-based practice                          │
└──────────────────────────────────────────────────────────┘
```
## 6️⃣ Mentor Recommendation Panel
```
┌──────────── Mentor Action Recommendations ───────────────┐
│ Suggested Actions:                                       │
│ ✓ Assign DI-focused micro-assessment                     │
│ ✓ Pair with peer for code walkthrough                    │
│ ✓ Recommend Layer 3 reinforcement module                 │
│                                                          │
│ [ Assign Assessment ]   [ Schedule Mentoring Session ]   │
└──────────────────────────────────────────────────────────┘
```
## 7️⃣ Mentor Control Philosophy (Embedded)

✔ AI never publishes without mentor action
✔ Mentor can override AI evaluation
✔ Analytics explain *why*, not just *what*
✔ Dashboard supports mentoring decisions

## 🌱 Design Summary

This dashboard ensures:

* Mentors remain decision-makers
* AI works as a silent assistant
* Assessment becomes guidance
* Learning stays human-centric

> **“The dashboard is not a control panel.
> It is a mentoring cockpit.”**


### Why this wireframe is important (mentor-to-mentor clarity)
* It **preserves mentor authority** at every step
* AI is visible only where it adds value, never where it replaces judgment
* Every screen answers a real mentoring question:
  * *What is the learner good at?*
  * *Where exactly is the gap?*
  * *What should I do next as a mentor?*

### What you can do next with this wireframe

You can now:
1. **Validate flow with mentors** (does this match how they think?)
2. Convert each section into:
   * UI stories (for developers)
   * Feature backlog (for product planning)
3. Map each screen to:
   * Data models
   * AI prompts
   * Analytics rules

### Recommended next step (very logical progression)
Choose one:
1️⃣ **Convert this wireframe into functional modules (backend services)**
2️⃣ **Design data models for assessments, skills, analytics**
3️⃣ **Create prompt templates tied to each dashboard action**
4️⃣ **Design learner-side dashboard (mirror view)**
5️⃣ **Turn this into a product requirement document (PRD)**


We are building something *very rare*:
**AI that strengthens mentors instead of sidelining them.**

# 🌼 TFLAssessment – Core Data Models

> **Purpose:** Define clean, extensible data models that align assessments, skills, and analytics with the Transflower Learning Framework (TFL).

These models are **technology-agnostic** and can be implemented in SQL / NoSQL / ORM-based systems.

## 1️⃣ Core Design Principles

✔ Skill-first, not question-first
✔ Layer-aware (TFL layers are first-class citizens)
✔ Mentor-centric (approval & overrides supported)
✔ Analytics-ready (every attempt produces insight)

## 2️⃣ Skill Taxonomy Models (Foundation)

### 🔹 TFL_Layer

```
LayerId (PK)
Name       // Engineering Foundations, Programming, etc.
Description
OrderIndex
```
### 🔹 Skill

```
SkillId (PK)
LayerId (FK)
Name       // e.g., ASP.NET Core
Description
```

### 🔹 SubSkill

```
SubSkillId (PK)
SkillId (FK)
Name            // e.g., Dependency Injection
Description
```

### 🔹 Concept

```
ConceptId (PK)
SubSkillId (FK)
Name            // e.g., Service Lifetimes
Description
```

### 🔹 LearningOutcome

```
OutcomeId (PK)
ConceptId (FK)
Statement       // Observable capability
BloomLevel      // Remember, Apply, Analyze, Create
```

📌 *This hierarchy ensures every assessment item maps to an outcome.*

## 3️⃣ Question & Assessment Models

### 🔹 QuestionBlueprint (Mentor-Defined)

```
BlueprintId (PK)
LayerId (FK)
SkillId (FK)
SubSkillId (FK)
ConceptId (FK)
OutcomeId (FK)
QuestionType        // MCQ, Coding, Scenario, Design
BloomLevel
Difficulty          // Easy, Medium, Hard
EvaluationType      // Auto, Rubric, Mentor
CreatedByMentorId
IsActive
```
### 🔹 Question

```
QuestionId (PK)
BlueprintId (FK)
QuestionText
Options             // JSON (for MCQ)
CorrectAnswer       // JSON / Code
Explanation
Difficulty
AI_Generated        // Boolean
Status              // Draft, Approved, Rejected
```
### 🔹 Assessment

```
AssessmentId (PK)
Name
LayerId (FK)
Type                // Diagnostic, Formative, Summative
DurationMinutes
CreatedByMentorId
Status              // Draft, Published, Closed
```

### 🔹 AssessmentQuestion

```
AssessmentQuestionId (PK)
AssessmentId (FK)
QuestionId (FK)
SequenceNumber
Marks
```

## 4️⃣ Learner & Attempt Models

### 🔹 Learner

```
LearnerId (PK)
Name
Email
Cohort
CurrentLayerId
```
### 🔹 AssessmentAttempt

```
AttemptId (PK)
AssessmentId (FK)
LearnerId (FK)
StartTime
EndTime
TotalScore
Status              // InProgress, Submitted, Evaluated
```

### 🔹 QuestionResponse

```
ResponseId (PK)
AttemptId (FK)
QuestionId (FK)
LearnerAnswer       // JSON / Code
ScoreAwarded
EvaluationNotes     // AI + Mentor comments
```

## 5️⃣ Analytics & Skill Insight Models

### 🔹 SkillPerformance

```
SkillPerformanceId (PK)
LearnerId (FK)
SkillId (FK)
MasteryPercentage
LastUpdated
```

### 🔹 ConceptPerformance

```
ConceptPerformanceId (PK)
LearnerId (FK)
ConceptId (FK)
MasteryPercentage
BloomWeakness       // e.g., Apply
```

### 🔹 SkillGap

```
SkillGapId (PK)
LearnerId (FK)
SkillId (FK)
Severity            // Low, Medium, High
Recommendation      // Suggested next action
```

### 🔹 MentorInsight

```
InsightId (PK)
LearnerId (FK)
GeneratedBy         // AI / Mentor
InsightText
CreatedOn
```

## 6️⃣ Mentor Control & Override Models
### 🔹 MentorReview
```
ReviewId (PK)
QuestionId (FK)
MentorId
Decision            // Approved, Modified, Rejected
Comments
ReviewedOn
```
### 🔹 EvaluationOverride

```
OverrideId (PK)
ResponseId (FK)
MentorId
OriginalScore
UpdatedScore
Reason
```

## 7️⃣ How Analytics Emerges Naturally
Each response contributes to:

* Concept mastery
* Skill strength
* Bloom-level gaps
* Role readiness

📌 No extra computation layer is required initially.

## 8️⃣ Mapping Models to Mentor Dashboard

| Dashboard Feature | Data Models Used    |
| ----------------- | ------------------- |
| Create Assessment | Blueprint, Question |
| Review AI Output  | MentorReview        |
| Skill Snapshot    | SkillPerformance    |
| Gap Detection     | SkillGap            |
| Recommendations   | MentorInsight       |

## 🌱 Design Insight
> **These models do not store questions alone.
> They store learning evidence.**

This structure ensures:
✔ Curriculum alignment
✔ AI safety & control
✔ Mentor authority
✔ Long-term scalability

## 🧭 Next Logical Step

1️⃣ Convert this into **ER diagrams**
2️⃣ Create **API contracts (DTOs)**
3️⃣ Design **prompt templates using these entities**
4️⃣ Build **analytics rules engine**
5️⃣ Implement **MVP database schema**


### Why this design is *right* for Transflower

This is not a typical “exam system” schema.

✔ **Skill-first** – everything traces back to *Layer → Skill → Concept → Outcome*
✔ **Mentor-safe** – approvals, overrides, reviews are built-in
✔ **AI-ready** – but never AI-dependent
✔ **Analytics-native** – insights emerge naturally from attempts
✔ **Scalable** – supports diagnostics → role readiness → long-term growth tracking

In short:

> **You’re not storing answers. You’re storing learning evidence.**

### How this aligns with Transflower's mentoring style

From your earlier prompts, you always ask:
* *Why is the learner weak here?*
* *What exactly is missing?*
* *What should I do next as a mentor?*

These models answer all three **without extra layers or hacks**.

### Very strong next steps (pick one)

Now that the foundation is solid, the next move should convert **structure → execution**:

1️⃣ **Design API contracts (DTOs) for Mentor Dashboard & Learner App**
2️⃣ **Create prompt templates that consume these models (Blueprint → Question)**
3️⃣ **Design analytics rules (how mastery % and gaps are calculated)**
4️⃣ **Create ER diagrams + physical DB schema (SQL-first)**
5️⃣ **Walk through one real example end-to-end (Layer → Skill → Assessment → Insight)**

If you want my recommendation as a system architect:
👉 **Go with #5 first** — it will validate everything emotionally and technically.

