# Quarterly Career Roadmap Generator

* **Daily Plan** = action
* **Weekly Plan** = correction
* **Monthly Milestone** = outcome
* **Quarterly Career Roadmap** = **DESTINATION CONTROL**

This is the layer where **institutions become career engines**.


## (TFL – Career Navigation System)

## 1️⃣ What Is a Quarterly Career Roadmap?

A **quarterly roadmap** answers one decisive question:

> “At the end of the next 90 days, what role should this learner be realistically *employable* for?”

Not:

* Courses completed ❌
* Certificates earned ❌

But:

* **Career positioning achieved** ✅
* **Hiring signal strength improved** ✅

## 2️⃣ Position in TFL Architecture

```
Quarterly Career Roadmap (Vision)
        ↓
Monthly Milestones (Contracts)
        ↓
Weekly Adaptive Plans (Steering)
        ↓
Daily Plans (Execution)
        ↓
Evidence & Employability Signals
```

This layer:

* Controls **direction drift**
* Enables **long-horizon mentoring**
* Aligns **employers, mentors, learners**
* Drives **placement outcomes**

## 3️⃣ MySQL Schema – Quarterly Career Engine

## 3.1 `quarterly_career_roadmaps`

**One roadmap per student per quarter**

```sql
CREATE TABLE quarterly_career_roadmaps (
    roadmap_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,

    quarter_label VARCHAR(20), -- e.g. Q2-2025
    quarter_start DATE NOT NULL,
    quarter_end DATE NOT NULL,

    target_job_role_id INT NOT NULL,
    target_employer_type ENUM(
        'Startup',
        'ProductCompany',
        'ServiceCompany',
        'Enterprise'
    ),

    career_theme VARCHAR(150),
    positioning_statement VARCHAR(255),

    expected_employability_status ENUM(
        'Exploration',
        'SkillBuilding',
        'JobReady',
        'InterviewPipeline',
        'Placed'
    ) NOT NULL,

    generated_by ENUM(
        'System',
        'Mentor'
    ) DEFAULT 'System',

    generation_reason VARCHAR(255),

    status ENUM(
        'Planned',
        'Active',
        'Completed',
        'Revised'
    ) DEFAULT 'Planned',

    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    UNIQUE (student_id, quarter_label),

    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (target_job_role_id) REFERENCES job_roles(job_role_id)
);
```

📌 This is the **career contract for 90 days**.

## 3.2 `roadmap_skill_strategy`

**Skill investment decisions**

```sql
CREATE TABLE roadmap_skill_strategy (
    strategy_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,
    skill_id INT NOT NULL,

    current_level DECIMAL(5,2),
    target_level DECIMAL(5,2),

    investment_priority ENUM(
        'MustWin',
        'StrongSupport',
        'Maintain'
    ) NOT NULL,

    rationale VARCHAR(255),

    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

📌 Prevents **overlearning low-impact skills**.

## 3.3 `roadmap_project_portfolio`

**Career-defining work**

```sql
CREATE TABLE roadmap_project_portfolio (
    project_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,

    project_title VARCHAR(150),
    project_type ENUM(
        'Capstone',
        'EmployerSimulation',
        'OpenSource',
        'StartupPrototype'
    ),

    core_skills VARCHAR(255),
    expected_business_value VARCHAR(255),

    completion_status ENUM(
        'Planned',
        'InProgress',
        'Delivered'
    ) DEFAULT 'Planned',

    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

📌 Employers hire from here.

## 3.4 `roadmap_interview_pipeline`

**Hiring readiness gates**

```sql
CREATE TABLE roadmap_interview_pipeline (
    pipeline_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,

    interview_type ENUM(
        'DSA',
        'Backend',
        'Frontend',
        'SystemDesign',
        'HR',
        'Behavioral'
    ),

    readiness_level ENUM(
        'NotReady',
        'Practicing',
        'MockCleared',
        'EmployerCleared'
    ) DEFAULT 'NotReady',

    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

## 3.5 `roadmap_risk_flags`

**Mentor foresight system**

```sql
CREATE TABLE roadmap_risk_flags (
    risk_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,

    risk_type ENUM(
        'LowConsistency',
        'SkillPlateau',
        'ConfidenceGap',
        'ProjectDelay',
        'InterviewAvoidance'
    ),

    severity ENUM(
        'Low',
        'Medium',
        'High'
    ),

    mitigation_plan TEXT,

    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

📌 This enables **preventive mentoring**.

## 4️⃣ Roadmap Generation Logic (Strategic Intelligence)

### Inputs

* Student history (last 3 months)
* Employer demand heatmap
* Skill readiness index
* Mentor capacity
* Student career intent

### Roadmap Patterns

| Student Profile              | Roadmap Theme        |
| ---------------------------- | -------------------- |
| Strong skills, no interviews | Interview Pipeline   |
| Skills weak, motivation high | Skill Foundation     |
| Projects missing             | Proof Building       |
| Employer urgent need         | Fast-track Placement |

### Example Roadmap Output

> **Q2 2025 Roadmap**
> *Target Role:* Junior Backend Developer
> *Theme:* “From learner to deployable engineer”
> *Outcome:* Interview-ready for startups & service companies

## 5️⃣ Quarterly → Monthly → Weekly Enforcement

- ✔ Monthly milestones must map to roadmap skills
- ✔ Weekly plans must feed roadmap projects
- ✔ Daily plans must not deviate from roadmap
- ✔ Mentor can revise roadmap mid-quarter


## 6️⃣ API DESIGN

## 6.1 Student APIs

### 🔹 View Career Roadmap

```
GET /api/student/career-roadmap/current
```

## 6.2 Mentor APIs

### 🔹 Mentor Adjust Roadmap

```
POST /api/mentor/career-roadmap/revise
```

```json
{
  "roadmapId": 3,
  "newTargetRoleId": 2,
  "reason": "Employer demand shift"
}
```

## 6.3 System APIs

### 🔹 Quarterly Roadmap Generator

```
POST /api/system/career-roadmap/generate
```

Runs:

* Every quarter
* On major employer signal change

## 7️⃣ Dashboard Integration

### Mentor Leadership Dashboard

* Placement probability curve
* Risk alerts
* Skill investment ROI

### Student View

* “Your next 90 days”
* Career identity clarity
* Proof checklist

### Employer View

* Talent pipeline preview
* Interview-ready candidates
* Project exposure

## 8️⃣ Why This Is Rare & Powerful (Mentor Reality)

Most learning platforms:

> “We teach skills.”

TFL says:

> “We **navigate careers**.”

This roadmap engine:

* Converts effort → employability
* Gives mentors leverage
* Aligns learning with hiring reality
* Creates trust with employers


## 🔜 Natural Evolution Options

- 1️⃣ **Placement probability model (ML-ready)**
- 2️⃣ **Employer matching algorithm**
- 3️⃣ **Career deviation detection**
- 4️⃣ **AI mentor explanation engine**
- 5️⃣ **End-to-end student journey simulation**



You have now architected:
- ✔ Execution engine
- ✔ Adaptation engine
- ✔ Outcome engine
- ✔ Career navigation engine

This is not an LMS.
This is a **Career Operating System**.

