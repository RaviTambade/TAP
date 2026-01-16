# 🏋️ Skill Gym – UI & UX Specification (TFL)

## 🎯 Product Goal

Create a **low-friction, habit-forming interface** that keeps skills fresh with **10–20 minute maintenance units**, prevents regression, and preserves job-readiness credibility.

## 🧠 Core UX Principles

* **Frictionless**: No setup, no context switching
* **Failure-first**: Real-world break → fix → explain
* **Time-boxed**: Always shows remaining minutes
* **Signal-driven**: Tasks appear because data says so
* **Non-judgmental**: No grades, only stability & freshness


## 🧭 Primary Personas

* **Student / Professional**: Wants confidence, not content overload
* **Mentor**: Wants early warnings, minimal intervention
* **Employer (Read-only)**: Wants freshness & reliability


## 🖥️ Information Architecture

```
Home (Today)
 ├─ Skill Gym
 │   ├─ Today’s Workout
 │   ├─ Skill Inventory
 │   ├─ Freshness Scores
 │   └─ History
 ├─ Job Readiness
 ├─ Insights
 └─ Settings
```

## 🏠 Home / Today Screen

### Purpose

Answer one question instantly:

> “What do I need to do **today** to stay reliable?”

### Components

* **Today’s Workout Card** (Primary CTA)
* **Time Budget** (e.g., 25 min remaining)
* **Risk Indicator** (Low / Medium / High)

### Microcopy

* “Keep skills warm.”
* “Prevent future panic.”


## 🏋️ Skill Gym – Today’s Workout

### Layout

```
[ ⏱ 18 minutes ]   [ Risk: Medium ]
----------------------------------
1. Async Programming (Failure Drill)
2. ORM Performance (Quick Fix)
3. Logging (Recall)
----------------------------------
[ Start Workout ]
```

### UX Details

* Tasks are **ordered by risk**
* Only **1–3 tasks max**
* Clear start → finish flow


## 🧩 Maintenance Unit (MU) Screen

### Structure

```
Skill: Asynchronous Programming
Type: Failure Maintenance
Time: 15 minutes

Scenario:
"API hangs under load. Logs attached."

[ Code / Logs Panel ]

Question:
What caused the hang? Fix it.

[ Submit Fix ]   [ Hint (-5%) ]
```

### UX Rules

* No scrolling between context
* Inline logs & code
* One decisive action


## ✅ Completion Feedback (No Grades)

### Feedback Card

```
✔ Skill Refreshed

Async Programming
Freshness: 78% → 91%
Risk Level: Medium → Low

Next Check: 7 days
```

### Emotion Design

* Calm
* Reassuring
* No dopamine spikes



## 📊 Skill Inventory Screen

### Grid View

| Skill             | Mastery | Freshness | Risk   |
| ----------------- | ------- | --------- | ------ |
| Async Programming | 72%     | 🟢 91%    | Low    |
| Debugging         | 68%     | 🟡 64%    | Medium |
| ORM               | 75%     | 🟢 88%    | Low    |
| Microservices     | 55%     | 🔴 42%    | High   |

### Interactions

* Click skill → history & drills
* Sort by risk or decay


## 📈 Skill Timeline (Per Skill)

```
Freshness
100% |          ●
 80% |     ●    │
 60% | ●        │
     |──────────┼──────── Time
        Last MU   Now
```

### Purpose

* Make decay **visible**
* Build trust in the system


## 🧠 Insights Screen

### Example Insight

> “Debugging skill shows decay after context switches. Schedule weekly failure drills.”

### Categories

* Drift Alerts
* Recovery Suggestions
* Readiness Impact


## 🧑‍🏫 Mentor View (Minimal Intervention)

### Dashboard

```
Students at Risk: 3
Recovered This Week: 5
Critical Regression: 1

[ View Details ]
```

### Drill-Down

* Skill causing risk
* Suggested intervention


## 🧾 Employer View (Read-only)

### Skill Freshness Card

```
Backend Developer

Async Programming: Fresh (91%)
Debugging: Stable (76%)
Microservices: Needs Refresh (52%)

Last Maintenance: 4 days ago
```

### Trust Signal

> “Skills verified & maintained.”


## 🎨 Visual Design Language

* **Color**: Neutral + risk accents (green/yellow/red)
* **Typography**: Calm, readable, no gamification
* **Motion**: Subtle progress transitions only
* **Dark Mode**: Default (developer-friendly)

## 🧠 Behavioral Design (Very Important)

* No streak pressure
* No leaderboards
* No public comparison
* Focus on **personal reliability**


## 🔐 Accessibility & Inclusion

* Keyboard-first navigation
* Color-blind safe indicators
* Clear language, no jargon


## 🔥 Why This UI Works

Traditional LMS:

> “Finish Chapter 6.”

Skill Gym:

> “Prevent a production failure in 15 minutes.”

This changes **identity**, not just behavior.

## 🚀 Next Iterations

* Skill Gym mobile UX
* Offline micro-drills
* IDE integration
* Calendar-based nudges


**Skill Gym is not a feature.
It is a professional habit.**
