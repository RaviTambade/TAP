
# Monthly Milestone Generator

## (TFL Strategic Progress Engine)

## 1️⃣ What Is a Monthly Milestone? (Mentor Definition)

A **monthly milestone** answers:

> “At the end of this month, what *new professional capability* should the student demonstrably have?”

Not:

* Chapters completed ❌
* Videos watched ❌

But:

* **Capabilities earned** ✅
* **Employability signals unlocked** ✅

## 2️⃣ Role of Monthly Milestones in TFL

```
Monthly Milestones (Strategy)
        ↓
Weekly Adaptive Plans (Direction)
        ↓
Daily Plans (Execution)
        ↓
Evidence + Signals
```

Monthly milestones:

* Set **non-negotiable outcomes**
* Control **scope creep**
* Enable **mentor accountability**
* Provide **employer-facing clarity**

## 3️⃣ MySQL Schema – Monthly Milestone Engine

## 3.1 `monthly_milestones`

**One record = one student per month**

```sql
CREATE TABLE monthly_milestones (
    milestone_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,

    milestone_month DATE NOT NULL, -- e.g. 2025-03-01

    primary_job_role_id INT NOT NULL,

    milestone_title VARCHAR(150),
    milestone_description TEXT,

    expected_employability_level ENUM(
        'Foundation',
        'Intermediate',
        'JobReady',
        'InterviewReady'
    ) NOT NULL,

    milestone_type ENUM(
        'SkillConsolidation',
        'ProjectDelivery',
        'InterviewReadiness',
        'EmployerDriven'
    ) NOT NULL,

    generated_by ENUM(
        'System',
        'Mentor'
    ) DEFAULT 'System',

    generation_reason VARCHAR(255),

    status ENUM(
        'Planned',
        'InProgress',
        'Achieved',
        'PartiallyAchieved'
    ) DEFAULT 'Planned',

    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    UNIQUE (student_id, milestone_month),

    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (primary_job_role_id) REFERENCES job_roles(job_role_id)
);
```

📌 This is the **contract for the month**.

## 3.2 `milestone_skill_outcomes`

**What skill maturity is expected by month-end**

```sql
CREATE TABLE milestone_skill_outcomes (
    outcome_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,
    skill_id INT NOT NULL,

    starting_score DECIMAL(5,2),
    expected_score DECIMAL(5,2),

    criticality ENUM(
        'Critical',
        'Important',
        'Supporting'
    ) DEFAULT 'Important',

    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

📌 This allows **hard accountability**.

## 3.3 `milestone_projects`

**Employer-visible proof**

```sql
CREATE TABLE milestone_projects (
    project_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,

    project_title VARCHAR(150),
    project_description TEXT,

    tech_stack VARCHAR(255),

    evaluation_type ENUM(
        'MentorReview',
        'AutoAssessment',
        'EmployerReview'
    ) DEFAULT 'MentorReview',

    completion_status ENUM(
        'NotStarted',
        'InProgress',
        'Completed'
    ) DEFAULT 'NotStarted',

    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id)
);
```

## 3.4 `milestone_interview_checkpoints`

**Readiness gates**

```sql
CREATE TABLE milestone_interview_checkpoints (
    checkpoint_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,

    checkpoint_type ENUM(
        'Technical',
        'HR',
        'SystemDesign',
        'Behavioral'
    ),

    expected_confidence_level INT CHECK (expected_confidence_level BETWEEN 1 AND 5),

    passed BOOLEAN DEFAULT FALSE,

    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id)
);
```

## 3.5 `milestone_evidence`

**Truth layer (no opinions allowed)**

```sql
CREATE TABLE milestone_evidence (
    evidence_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,

    evidence_type ENUM(
        'AssessmentScore',
        'ProjectLink',
        'MentorRating',
        'EmployerFeedback'
    ),

    evidence_reference VARCHAR(255),
    score DECIMAL(5,2),

    submitted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id)
);
```

📌 This table prevents *false confidence*.

## 4️⃣ Monthly → Weekly → Daily Alignment Rules

### System Constraints

- ✔ Weekly plans **must map** to milestone skills
- ✔ Daily plans **must feed** weekly goals
- ✔ Missing milestone outcomes → recovery month
- ✔ Employer-driven milestones override syllabus

## 5️⃣ Milestone Generation Logic (The Brain)

### Inputs

* Student skill trajectory (last 4 weeks)
* Employer job role requirements
* Project backlog
* Mentor constraints
* Confidence vs performance gap

### Sample Rules

| Condition              | Milestone Type     |
| ---------------------- | ------------------ |
| Core skills weak       | SkillConsolidation |
| Skills OK, no proof    | ProjectDelivery    |
| Skills + project done  | InterviewReadiness |
| Employer urgent demand | EmployerDriven     |

### Example Generated Milestone

> **March Milestone:**
> “Deliver a production-grade REST API project and clear SQL + API technical interview checkpoint.”


## 6️⃣ API DESIGN

## 6.1 Student APIs

### 🔹 View Monthly Milestone

```
GET /api/student/monthly-milestone/current
```

### 🔹 Upload Evidence

```
POST /api/student/monthly-milestone/evidence
```

```json
{
  "milestoneId": 4,
  "type": "ProjectLink",
  "reference": "https://github.com/student/employee-api"
}
```

## 6.2 Mentor APIs

### 🔹 Mentor Review Milestone

```
POST /api/mentor/monthly-milestone/review
```

```json
{
  "milestoneId": 4,
  "status": "PartiallyAchieved",
  "feedback": "Good API structure, improve error handling"
}
```

## 6.3 System APIs

### 🔹 Monthly Milestone Generator (CRON)

```
POST /api/system/monthly-milestone/generate
```

Runs:

* First day of every month
* Or mentor-triggered

## 7️⃣ Dashboard Integration

### Mentor Dashboard

* Milestone risk heatmap
* Skill vs evidence mismatch
* Employer alignment meter

### Student Dashboard

* “This Month’s Mission”
* Proof checklist
* Confidence gauge

### Employer Dashboard

* Capability snapshot
* Project maturity
* Interview readiness signal

## 8️⃣ Why This Is a Differentiator (Mentor Reality)

Most platforms measure:

> “How much did you study?”

TFL measures:

> “What can you now *prove*?”

This **monthly milestone engine**:

* Prevents endless learning
* Forces outcome orientation
* Creates hiring-ready signals
* Aligns all layers cleanly


## 🔜 Powerful Next Steps (Choose One)

1️⃣ **Quarterly career roadmap generator**
2️⃣ **Interview-readiness scorecard (SQL + UI)**
3️⃣ **Skill decay & regression detection**
4️⃣ **AI mentor reasoning (“Why this milestone?”)**
5️⃣ **Employer shortlisting algorithm**

Tell me where you want to go next —
You are now designing a **career OS**, not an LMS 🚀
