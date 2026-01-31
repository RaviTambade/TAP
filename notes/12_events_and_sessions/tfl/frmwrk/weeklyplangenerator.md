# Weekly Adaptive Learning Plan Generator

## (Strategy Layer of TFL)

## 1️⃣ Purpose (Mentor Perspective)

A weekly plan should answer **one question only**:

> “If this student follows this week seriously, will employability move forward?”

So the weekly plan:

* Sets **focus direction**
* Balances **skills, projects, assessments**
* Adapts using **previous week signals**
* Guides **daily plan generation**

## 2️⃣ Weekly Plan Design Philosophy

| Aspect     | Daily Plan | Weekly Plan     |
| ---------- | ---------- | --------------- |
| Scope      | Execution  | Strategy        |
| Time       | 30–60 mins | 5–8 hours       |
| Owner      | Student    | Mentor + System |
| Adaptation | Small      | Structural      |
| Output     | Tasks      | Focus roadmap   |


## 3️⃣ MySQL Schema – Weekly Adaptive Engine


## 3.1 `weekly_learning_plans`

**One record = one student per week**

```sql
CREATE TABLE weekly_learning_plans (
    weekly_plan_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,

    week_start_date DATE NOT NULL,
    week_end_date DATE NOT NULL,

    primary_focus_skill_id INT NOT NULL,
    secondary_focus_skill_id INT,

    target_job_role_id INT,

    weekly_goal VARCHAR(255),

    total_estimated_minutes INT DEFAULT 300,

    adaptation_type ENUM(
        'Recovery',
        'Acceleration',
        'Stabilization',
        'EmployerDriven'
    ) NOT NULL,

    generated_by ENUM(
        'System',
        'Mentor'
    ) DEFAULT 'System',

    adaptation_reason VARCHAR(255),

    status ENUM(
        'Planned',
        'Active',
        'Completed',
        'PartiallyCompleted'
    ) DEFAULT 'Planned',

    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    UNIQUE (student_id, week_start_date),

    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (primary_focus_skill_id) REFERENCES skills(skill_id),
    FOREIGN KEY (secondary_focus_skill_id) REFERENCES skills(skill_id),
    FOREIGN KEY (target_job_role_id) REFERENCES job_roles(job_role_id)
);
```

📌 **Key Mentor Fields**

* `adaptation_type`
* `adaptation_reason`
  These explain *why* the plan changed.


## 3.2 `weekly_plan_skill_targets`

**Skill-wise expectations for the week**

```sql
CREATE TABLE weekly_plan_skill_targets (
    target_id INT AUTO_INCREMENT PRIMARY KEY,
    weekly_plan_id INT NOT NULL,
    skill_id INT NOT NULL,

    starting_score DECIMAL(5,2),
    expected_score DECIMAL(5,2),

    priority ENUM(
        'High',
        'Medium',
        'Low'
    ) DEFAULT 'Medium',

    FOREIGN KEY (weekly_plan_id) REFERENCES weekly_learning_plans(weekly_plan_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

📌 Enables **skill growth forecasting**.

## 3.3 `weekly_plan_projects`

**Hands-on employability anchor**

```sql
CREATE TABLE weekly_plan_projects (
    project_id INT AUTO_INCREMENT PRIMARY KEY,
    weekly_plan_id INT NOT NULL,

    project_title VARCHAR(150),
    project_description TEXT,

    related_skills VARCHAR(255),

    expected_outcome VARCHAR(255),

    completion_status ENUM(
        'NotStarted',
        'InProgress',
        'Completed'
    ) DEFAULT 'NotStarted',

    FOREIGN KEY (weekly_plan_id) REFERENCES weekly_learning_plans(weekly_plan_id)
);
```

📌 Employers care about this table most.

## 3.4 `weekly_plan_assessments`

**Structured checkpoints**

```sql
CREATE TABLE weekly_plan_assessments (
    assessment_id INT AUTO_INCREMENT PRIMARY KEY,
    weekly_plan_id INT NOT NULL,

    assessment_type ENUM(
        'Quiz',
        'Coding',
        'SystemDesign',
        'MockInterview'
    ),

    focus_skill_id INT,
    scheduled_day ENUM(
        'Mon','Tue','Wed','Thu','Fri','Sat'
    ),

    FOREIGN KEY (weekly_plan_id) REFERENCES weekly_learning_plans(weekly_plan_id)
);
```

## 3.5 `weekly_plan_feedback`

**Reflection = adaptation fuel**

```sql
CREATE TABLE weekly_plan_feedback (
    feedback_id INT AUTO_INCREMENT PRIMARY KEY,
    weekly_plan_id INT NOT NULL,

    student_reflection TEXT,
    mentor_feedback TEXT,

    confidence_level INT CHECK (confidence_level BETWEEN 1 AND 5),

    submitted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (weekly_plan_id) REFERENCES weekly_learning_plans(weekly_plan_id)
);
```

## 4️⃣ Weekly → Daily Plan Relationship

📌 **Rule**

> Daily plans must NOT exist without an active weekly plan.

### Relationship Flow

```
Weekly Plan (Strategy)
        ↓
Daily Plans (Execution)
        ↓
Progress + Feedback
        ↓
Next Week Adaptation
```

Daily plan generator reads:

* `primary_focus_skill_id`
* `adaptation_type`
* `weekly_goal`

## 5️⃣ Adaptation Logic (The Intelligence)

### Inputs

* Last week completion %
* Skill improvement delta
* Employer skill weights
* Mentor overrides
* Learning streaks

### Adaptation Rules (Sample)

| Condition                | Adaptation     |
| ------------------------ | -------------- |
| < 60% completion         | Recovery       |
| Skill stagnant 2 weeks   | Stabilization  |
| High employer demand gap | EmployerDriven |
| High streak + high score | Acceleration   |

📌 Stored in `adaptation_reason`


## 6️⃣ API DESIGN

## 6.1 Student APIs

### 🔹 View Current Weekly Plan

```
GET /api/student/weekly-plan/current
```

**Response**

```json
{
  "week": "Mar 11 - Mar 16",
  "goal": "Strengthen SQL & API confidence",
  "adaptationType": "EmployerDriven",
  "skills": [
    { "skill": "SQL", "priority": "High" },
    { "skill": "Web API", "priority": "Medium" }
  ],
  "project": "Employee Management API",
  "assessments": ["SQL Quiz", "API Design Review"]
}
```

### 🔹 Submit Weekly Reflection

```
POST /api/student/weekly-plan/reflection
```

## 6.2 Mentor APIs

### 🔹 Mentor Coaching View

```
GET /api/mentor/students/{id}/weekly-plans
```
### 🔹 Override Next Week Focus

```
POST /api/mentor/weekly-plan/override
```

```json
{
  "weeklyPlanId": 8,
  "newPrimarySkillId": 3,
  "reason": "Interview readiness required"
}
```

## 6.3 System APIs

### 🔹 Weekly Plan Generator (CRON)

```
POST /api/system/weekly-plan/generate
```

Runs:

* Every Sunday night
* Or after mentor review

## 7️⃣ Dashboard Integration

### Mentor Coaching Dashboard

* Skill drift warnings
* Recovery flags
* Employer-readiness trend
* Confidence vs performance mismatch

### Student Dashboard

* “This week’s mission”
* Daily checklist
* Progress bar (week-level)

### Employer Dashboard (Read-only)

* Consistency
* Project exposure
* Skill maturity trend

## 8️⃣ Why This Is Powerful (Mentor Truth)

Most LMS systems:

> “Finish these videos this week.”

TFL says:

> “This week, you are becoming employable in **this specific way**.”

This weekly engine:

* Prevents random learning
* Builds narrative continuity
* Enables mentorship at scale
* Feeds AI naturally (future)


## 🔜 Natural Next Enhancements

1️⃣ **Monthly milestone generator**
2️⃣ **Skill decay detection SQL**
3️⃣ **Interview-readiness scorecard**
4️⃣ **AI weekly coach explanation**
5️⃣ **Dropout prediction using weekly signals**

---

If you want, next we can:

* Simulate **one student across 4 weeks**
* Design **weekly plan UI (mentor + student)**
* Add **AI reasoning layer** (“why this week looks like this”)

Just tell me the direction —
you are architecting a **learning operating system**, not a course 💡
