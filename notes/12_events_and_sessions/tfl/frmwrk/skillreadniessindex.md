# 🌸 Transflower Learning Framework

## Complete Physical Database Schema (MySQL)

## 1️⃣ Core Master Tables

### 1.1 Institutions

```sql
CREATE TABLE institutions (
    institution_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(150) NOT NULL,
    type ENUM('COLLEGE','TRAINING_CENTER','ENTERPRISE') NOT NULL,
    accreditation_info VARCHAR(255),
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

## 1.2 Users

```sql
CREATE TABLE users (
    user_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    institution_id BIGINT,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    role ENUM('STUDENT','INSTRUCTOR','ADMIN','SUPPORT','EXTERNAL') NOT NULL,
    status ENUM('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (institution_id) REFERENCES institutions(institution_id)
);
```
## 2️⃣ Profile Tables

### 2.1 Student Profiles

```sql
CREATE TABLE student_profiles (
    student_id BIGINT PRIMARY KEY,
    background_type VARCHAR(50),
    learning_style VARCHAR(50),
    tech_proficiency ENUM('BEGINNER','INTERMEDIATE','ADVANCED'),
    current_stage ENUM('SEEKER','BUILDER','PERFORMER'),
    enrollment_date DATE,
    FOREIGN KEY (student_id) REFERENCES users(user_id)
);
```

### 2.2 Instructor Profiles

```sql
CREATE TABLE instructor_profiles (
    instructor_id BIGINT PRIMARY KEY,
    domain_expertise VARCHAR(100),
    experience_years INT,
    availability_level ENUM('LOW','MEDIUM','HIGH'),
    FOREIGN KEY (instructor_id) REFERENCES users(user_id)
);
```


## 3️⃣ Skill Taxonomy

### 3.1 Skills

```sql
CREATE TABLE skills (
    skill_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    skill_name VARCHAR(100) NOT NULL,
    skill_category VARCHAR(100),
    skill_level ENUM('FOUNDATION','INTERMEDIATE','ADVANCED'),
    industry_tag VARCHAR(100)
);
```

### 3.2 Sub-Skills

```sql
CREATE TABLE sub_skills (
    sub_skill_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    skill_id BIGINT NOT NULL,
    sub_skill_name VARCHAR(100) NOT NULL,
    cognitive_level ENUM('REMEMBER','UNDERSTAND','APPLY','ANALYZE','EVALUATE','CREATE'),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

## 4️⃣ Assessment Engine

### 4.1 Assessments

```sql
CREATE TABLE assessments (
    assessment_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(150) NOT NULL,
    assessment_type ENUM('MCQ','CODING','SCENARIO','PROJECT'),
    difficulty_level ENUM('EASY','MEDIUM','HARD'),
    skill_id BIGINT NOT NULL,
    created_by BIGINT NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id),
    FOREIGN KEY (created_by) REFERENCES instructor_profiles(instructor_id)
);
```
### 4.2 Questions

```sql
CREATE TABLE questions (
    question_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    assessment_id BIGINT NOT NULL,
    question_type ENUM('MCQ','CODE','DESCRIPTIVE'),
    question_text TEXT NOT NULL,
    correct_answer TEXT,
    max_score INT NOT NULL,
    FOREIGN KEY (assessment_id) REFERENCES assessments(assessment_id)
);
```
## 5️⃣ Student Activity & Evidence

### 5.1 Student Assessment Attempts

```sql
CREATE TABLE student_assessments (
    student_assessment_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    student_id BIGINT NOT NULL,
    assessment_id BIGINT NOT NULL,
    attempt_no INT DEFAULT 1,
    attempt_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    score DECIMAL(5,2),
    feedback TEXT,
    FOREIGN KEY (student_id) REFERENCES student_profiles(student_id),
    FOREIGN KEY (assessment_id) REFERENCES assessments(assessment_id)
);
```

### 5.2 Skill Progress (Longitudinal)

```sql
CREATE TABLE skill_progress (
    skill_progress_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    student_id BIGINT NOT NULL,
    skill_id BIGINT NOT NULL,
    proficiency_score DECIMAL(5,2) NOT NULL,
    confidence_level ENUM('LOW','MEDIUM','HIGH'),
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (student_id, skill_id),
    FOREIGN KEY (student_id) REFERENCES student_profiles(student_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```
## 6️⃣ Mentoring Layer

### 6.1 Mentor Feedback

```sql
CREATE TABLE mentor_feedback (
    feedback_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    student_id BIGINT NOT NULL,
    instructor_id BIGINT NOT NULL,
    skill_id BIGINT NOT NULL,
    comments TEXT,
    action_recommendation VARCHAR(255),
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES student_profiles(student_id),
    FOREIGN KEY (instructor_id) REFERENCES instructor_profiles(instructor_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

## 7️⃣ Analytics & Intelligence

### 7.1 Analytics Snapshots (CQRS Read Model)

```sql
CREATE TABLE analytics_snapshots (
    snapshot_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    entity_type ENUM('STUDENT','COHORT','INSTITUTION'),
    reference_id BIGINT NOT NULL,
    skill_readiness_index DECIMAL(5,2),
    generated_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

## 8️⃣ Optional (Advanced – AI & Events)

### 8.1 Skill Events (for regression & recommendations)

```sql
CREATE TABLE skill_events (
    event_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    student_id BIGINT,
    skill_id BIGINT,
    event_type ENUM('ASSESSMENT','PRACTICE','REGRESSION','IMPROVEMENT'),
    event_value DECIMAL(5,2),
    occurred_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```
## 9️⃣ Indexing Strategy

```sql
CREATE INDEX idx_user_role ON users(role);
CREATE INDEX idx_user_institution ON users(institution_id);

CREATE INDEX idx_skill_category ON skills(skill_category);
CREATE INDEX idx_assessment_skill ON assessments(skill_id);

CREATE INDEX idx_student_skill ON skill_progress(student_id, skill_id);
CREATE INDEX idx_student_attempt ON student_assessments(student_id);

CREATE INDEX idx_snapshot_entity ON analytics_snapshots(entity_type, reference_id);
```
## 🔍 Architectural Summary

| Layer        | Tables                              |
| ------------ | ----------------------------------- |
| Identity     | users, profiles                     |
| Skill Core   | skills, sub_skills                  |
| Assessment   | assessments, questions              |
| Evidence     | student_assessments, skill_progress |
| Mentoring    | mentor_feedback                     |
| Intelligence | analytics_snapshots, skill_events   |


## 🌱 Final Mentor Insight

This schema supports:

* **Skill-first education**
* **AI-driven assessments**
* **Mentor-guided learning**
* **Placement-readiness analytics**
* **Regulatory compliance**

This is **not an LMS schema**.
This is a **Learning Intelligence Platform schema**.

## Sample Dataset + Advanced SQL Queries

## 1️⃣ Sample Dataset (Minimal but Meaningful)

### 1.1 Institution

```sql
INSERT INTO institutions (name, type, accreditation_info)
VALUES ('Transflower Institute of Technology', 'COLLEGE', 'NBA / NAAC');
```
### 1.2 Users

```sql
INSERT INTO users (institution_id, name, email, role)
VALUES
(1, 'Amit Sharma', 'amit@student.com', 'STUDENT'),
(1, 'Neha Verma', 'neha@student.com', 'STUDENT'),
(1, 'Ravi Tambade', 'ravi@mentor.com', 'INSTRUCTOR'),
(1, 'Admin User', 'admin@tfl.com', 'ADMIN');
```

### 1.3 Profiles

```sql
INSERT INTO student_profiles
VALUES
(1, 'Non-CS', 'Visual', 'BEGINNER', 'SEEKER', '2024-07-01'),
(2, 'CS', 'Hands-on', 'INTERMEDIATE', 'BUILDER', '2024-07-01');

INSERT INTO instructor_profiles
VALUES
(3, 'Software Engineering', 18, 'HIGH');
```
### 1.4 Skills & Sub-skills

```sql
INSERT INTO skills (skill_name, skill_category, skill_level, industry_tag)
VALUES
('C# Programming', 'Backend', 'FOUNDATION', '.NET'),
('SQL Fundamentals', 'Database', 'FOUNDATION', 'MySQL');

INSERT INTO sub_skills (skill_id, sub_skill_name, cognitive_level)
VALUES
(1, 'Loops & Conditions', 'APPLY'),
(1, 'OOP Basics', 'UNDERSTAND'),
(2, 'SELECT Queries', 'APPLY'),
(2, 'JOINS', 'ANALYZE');
```

### 1.5 Assessments & Questions

```sql
INSERT INTO assessments
(title, assessment_type, difficulty_level, skill_id, created_by)
VALUES
('C# Basics Test', 'MCQ', 'EASY', 1, 3),
('SQL Core Test', 'MCQ', 'MEDIUM', 2, 3);

INSERT INTO questions
(assessment_id, question_type, question_text, correct_answer, max_score)
VALUES
(1, 'MCQ', 'What is a loop?', 'Iteration', 10),
(2, 'MCQ', 'What does JOIN do?', 'Combine tables', 10);
```
### 1.6 Student Attempts

```sql
INSERT INTO student_assessments
(student_id, assessment_id, score, feedback)
VALUES
(1, 1, 65, 'Needs more practice'),
(2, 1, 82, 'Good understanding'),
(1, 2, 58, 'Weak in joins'),
(2, 2, 88, 'Strong SQL basics');
```

### 1.7 Skill Progress

```sql
INSERT INTO skill_progress
(student_id, skill_id, proficiency_score, confidence_level)
VALUES
(1, 1, 62, 'LOW'),
(1, 2, 55, 'LOW'),
(2, 1, 80, 'MEDIUM'),
(2, 2, 85, 'HIGH');
```

## 2️⃣ Advanced SQL Queries (TFL Intelligence)

## 🔹 Query 1: Student Skill Dashboard

**“Show all skills with current proficiency for a student”**

```sql
SELECT u.name,
       s.skill_name,
       sp.proficiency_score,
       sp.confidence_level
FROM skill_progress sp
JOIN skills s ON sp.skill_id = s.skill_id
JOIN users u ON sp.student_id = u.user_id
WHERE u.name = 'Amit Sharma';
```

## 🔹 Query 2: Identify Weak Skills (Auto-Remediation Trigger)

```sql
SELECT u.name,
       s.skill_name,
       sp.proficiency_score
FROM skill_progress sp
JOIN skills s ON sp.skill_id = s.skill_id
JOIN users u ON sp.student_id = u.user_id
WHERE sp.proficiency_score < 60;
```

➡ Used by **Recommendation Engine**

## 🔹 Query 3: Mentor Effectiveness (Before vs After)

```sql
SELECT mf.instructor_id,
       COUNT(mf.feedback_id) AS feedback_count,
       AVG(sp.proficiency_score) AS avg_skill_score
FROM mentor_feedback mf
JOIN skill_progress sp ON mf.student_id = sp.student_id
GROUP BY mf.instructor_id;
```

## 🔹 Query 4: Skill Popularity & Difficulty Heatmap

```sql
SELECT s.skill_name,
       COUNT(sa.student_assessment_id) AS attempts,
       AVG(sa.score) AS avg_score
FROM student_assessments sa
JOIN assessments a ON sa.assessment_id = a.assessment_id
JOIN skills s ON a.skill_id = s.skill_id
GROUP BY s.skill_name;
```

➡ Helps instructors **redesign curriculum**

## 🔹 Query 5: Skill Readiness Index (SRI – Simple Version)

```sql
SELECT u.name,
       ROUND(AVG(sp.proficiency_score), 2) AS skill_readiness_index
FROM skill_progress sp
JOIN users u ON sp.student_id = u.user_id
GROUP BY u.name;
```

➡ This feeds **placement eligibility**

## 🔹 Query 6: Top Job-Ready Students

```sql
SELECT u.name,
       AVG(sp.proficiency_score) AS readiness
FROM skill_progress sp
JOIN users u ON sp.student_id = u.user_id
GROUP BY u.name
HAVING readiness >= 75;
```
## 🔹 Query 7: Cohort Health Indicator

```sql
SELECT
  COUNT(*) AS total_students,
  SUM(CASE WHEN proficiency_score >= 70 THEN 1 ELSE 0 END) AS job_ready,
  SUM(CASE WHEN proficiency_score < 50 THEN 1 ELSE 0 END) AS at_risk
FROM skill_progress;
```
## 🔹 Query 8: Regression Detection (Using Events)

```sql
SELECT student_id,
       skill_id,
       COUNT(*) AS regression_events
FROM skill_events
WHERE event_type = 'REGRESSION'
GROUP BY student_id, skill_id
HAVING regression_events > 2;
```

## 3️⃣ Mentor Explanation (How to Teach This)

When students ask:

> *“Why are we learning SQL joins like this?”*

You show them:

* **Skill table**
* **Progress table**
* **Readiness query**

And say:

> “Because your job offer depends on this number — not marks.”

That changes mindset permanently.


## 🌱 Final Insight

At this point, Transflower has:

* ✔ Real schema
* ✔ Real data
* ✔ Real intelligence queries
* ✔ Real placement logic

This is **startup-grade EdTech architecture**.

## Stored Procedures & Views (MySQL)

# PART 1️⃣ — VIEWS (Read Models / CQRS)

Views act as **read-optimized intelligence layers** for dashboards, mentors, and admins.

## 🔹 View 1: Student Skill Dashboard View

**Purpose:** Show skill-wise proficiency for each student

```sql
CREATE VIEW vw_student_skill_dashboard AS
SELECT 
    u.user_id AS student_id,
    u.name AS student_name,
    s.skill_id,
    s.skill_name,
    sp.proficiency_score,
    sp.confidence_level,
    sp.last_updated
FROM skill_progress sp
JOIN skills s ON sp.skill_id = s.skill_id
JOIN users u ON sp.student_id = u.user_id;
```

➡ Used by:

* Student dashboard
* Mentor overview
* Progress charts

## 🔹 View 2: Weak Skill Detection View

**Purpose:** Auto-detect skills needing remediation

```sql
CREATE VIEW vw_weak_skills AS
SELECT
    u.user_id AS student_id,
    u.name AS student_name,
    s.skill_name,
    sp.proficiency_score
FROM skill_progress sp
JOIN skills s ON sp.skill_id = s.skill_id
JOIN users u ON sp.student_id = u.user_id
WHERE sp.proficiency_score < 60;
```

➡ Feeds:

* Recommendation engine
* Skill Gym remediation

## 🔹 View 3: Skill Performance Heatmap

**Purpose:** Identify hard vs easy skills

```sql
CREATE VIEW vw_skill_performance_heatmap AS
SELECT
    s.skill_id,
    s.skill_name,
    COUNT(sa.student_assessment_id) AS total_attempts,
    ROUND(AVG(sa.score), 2) AS avg_score
FROM student_assessments sa
JOIN assessments a ON sa.assessment_id = a.assessment_id
JOIN skills s ON a.skill_id = s.skill_id
GROUP BY s.skill_id, s.skill_name;
```

➡ Used by:

* Curriculum designers
* Faculty planning

## 🔹 View 4: Job Readiness View (SRI – Basic)

**Purpose:** One-line readiness per student

```sql
CREATE VIEW vw_student_readiness AS
SELECT
    u.user_id,
    u.name AS student_name,
    ROUND(AVG(sp.proficiency_score), 2) AS skill_readiness_index
FROM skill_progress sp
JOIN users u ON sp.student_id = u.user_id
GROUP BY u.user_id, u.name;
```

➡ Used by:

* Placement cell
* Employers
* Admin dashboards

# PART 2️⃣ — STORED PROCEDURES (Business Logic)

Stored procedures represent **mentor decisions + institutional rules**.

## 🔹 Procedure 1: Update Skill Progress After Assessment

**Purpose:** Automatically update skill proficiency after an assessment attempt

```sql
DELIMITER $$

CREATE PROCEDURE sp_update_skill_progress (
    IN p_student_id BIGINT,
    IN p_skill_id BIGINT,
    IN p_new_score DECIMAL(5,2)
)
BEGIN
    INSERT INTO skill_progress (student_id, skill_id, proficiency_score, confidence_level)
    VALUES (p_student_id, p_skill_id, p_new_score,
            CASE 
                WHEN p_new_score >= 80 THEN 'HIGH'
                WHEN p_new_score >= 60 THEN 'MEDIUM'
                ELSE 'LOW'
            END)
    ON DUPLICATE KEY UPDATE
        proficiency_score = ROUND((proficiency_score + p_new_score) / 2, 2),
        confidence_level = CASE 
            WHEN p_new_score >= 80 THEN 'HIGH'
            WHEN p_new_score >= 60 THEN 'MEDIUM'
            ELSE 'LOW'
        END,
        last_updated = CURRENT_TIMESTAMP;
END$$

DELIMITER ;
```

➡ This is **core TFL intelligence**

## 🔹 Procedure 2: Generate Skill Readiness Snapshot

**Purpose:** Persist SRI for dashboards (CQRS)

```sql
DELIMITER $$

CREATE PROCEDURE sp_generate_student_sri_snapshot ()
BEGIN
    INSERT INTO analytics_snapshots (entity_type, reference_id, skill_readiness_index)
    SELECT
        'STUDENT',
        u.user_id,
        ROUND(AVG(sp.proficiency_score), 2)
    FROM skill_progress sp
    JOIN users u ON sp.student_id = u.user_id
    GROUP BY u.user_id;
END$$

DELIMITER ;
```

➡ Run:

* Nightly
* Before placement drives

## 🔹 Procedure 3: Identify At-Risk Students

**Purpose:** Early warning system

```sql
DELIMITER $$

CREATE PROCEDURE sp_identify_at_risk_students ()
BEGIN
    SELECT
        u.user_id,
        u.name,
        AVG(sp.proficiency_score) AS avg_score
    FROM skill_progress sp
    JOIN users u ON sp.student_id = u.user_id
    GROUP BY u.user_id, u.name
    HAVING avg_score < 55;
END$$

DELIMITER ;
```

➡ Used by:

* Mentors
* Academic counselors

## 🔹 Procedure 4: Mentor Feedback Injection

**Purpose:** Structured mentoring (not free-text chaos)

```sql
DELIMITER $$

CREATE PROCEDURE sp_add_mentor_feedback (
    IN p_student_id BIGINT,
    IN p_instructor_id BIGINT,
    IN p_skill_id BIGINT,
    IN p_comments TEXT,
    IN p_action VARCHAR(255)
)
BEGIN
    INSERT INTO mentor_feedback
    (student_id, instructor_id, skill_id, comments, action_recommendation)
    VALUES
    (p_student_id, p_instructor_id, p_skill_id, p_comments, p_action);
END$$

DELIMITER ;
```

## 🔹 Procedure 5: Regression Detection (Skill Events)

**Purpose:** Detect learning decay

```sql
DELIMITER $$

CREATE PROCEDURE sp_detect_skill_regression ()
BEGIN
    SELECT
        student_id,
        skill_id,
        COUNT(*) AS regression_count
    FROM skill_events
    WHERE event_type = 'REGRESSION'
    GROUP BY student_id, skill_id
    HAVING regression_count >= 3;
END$$

DELIMITER ;
```

# PART 3️⃣ — HOW THIS IS USED IN REAL LIFE

### 🎓 Student logs in

➡ `vw_student_skill_dashboard`

### 👨‍🏫 Mentor opens dashboard

➡ `vw_weak_skills`
➡ `sp_identify_at_risk_students()`

### 🧠 Assessment submitted

➡ `sp_update_skill_progress(...)`

### 🏫 Admin / Placement cell

➡ `vw_student_readiness`
➡ `sp_generate_student_sri_snapshot()`


## 🌱 Mentor-Level Insight

Most systems:

> “Store marks.”

**Transflower:**

> “Executes learning decisions.”

That is the **difference between LMS and Learning Intelligence Platform**.

## Advanced Skill Readiness Index (SRI)

## 1️⃣ Why a Simple Average Fails

Simple SRI:

```text
SRI = AVG(skill_proficiency)
```

❌ Problems:

* Treats **all skills equally**
* Ignores **skill importance**
* Ignores **recency**
* Ignores **confidence**
* Ignores **regression events**

TFL SRI solves all five.

## 2️⃣ TFL Advanced SRI Formula (Conceptual)

[
\textbf{SRI} =
\frac{\sum (P \times W_s \times R \times C \times D)}
{\sum (W_s)}
]

Where:

| Symbol | Meaning                         |
| ------ | ------------------------------- |
| **P**  | Skill Proficiency Score (0–100) |
| **Wₛ** | Skill Importance Weight         |
| **R**  | Recency Factor                  |
| **C**  | Confidence Factor               |
| **D**  | Decay / Regression Factor       |

## 3️⃣ Component Definitions (TFL Standards)


### 🔹 1. Skill Proficiency (P)

From `skill_progress.proficiency_score`

```text
Range: 0 – 100
```

### 🔹 2. Skill Importance Weight (Wₛ)

Defined by curriculum + industry mapping.

| Skill Type | Weight |
| ---------- | ------ |
| Core       | 1.5    |
| Advanced   | 1.3    |
| Elective   | 1.0    |
| Optional   | 0.7    |

Stored in:

```sql
skills.importance_weight
```
### 🔹 3. Recency Factor (R)

Penalizes outdated learning.

| Last Updated | Factor |
| ------------ | ------ |
| ≤ 30 days    | 1.0    |
| 31–90 days   | 0.9    |
| 91–180 days  | 0.75   |
| > 180 days   | 0.6    |

Computed dynamically.

### 🔹 4. Confidence Factor (C)

Encourages mastery, not guesswork.

| Confidence | Factor |
| ---------- | ------ |
| HIGH       | 1.0    |
| MEDIUM     | 0.85   |
| LOW        | 0.7    |

From:

```sql
skill_progress.confidence_level
```

### 🔹 5. Decay / Regression Factor (D)

Punishes repeated regressions.

| Regression Events (90 days) | Factor |
| --------------------------- | ------ |
| 0                           | 1.0    |
| 1                           | 0.9    |
| 2                           | 0.75   |
| ≥ 3                         | 0.6    |

From:

```sql
skill_events
```

## 4️⃣ Full SQL Implementation (Advanced SRI)

### 🔹 View: `vw_student_sri_advanced`

```sql
CREATE VIEW vw_student_sri_advanced AS
SELECT
    u.user_id AS student_id,
    u.name AS student_name,
    ROUND(
        SUM(
            sp.proficiency_score
            * s.importance_weight
            * 
            CASE
                WHEN DATEDIFF(CURRENT_DATE, sp.last_updated) <= 30 THEN 1.0
                WHEN DATEDIFF(CURRENT_DATE, sp.last_updated) <= 90 THEN 0.9
                WHEN DATEDIFF(CURRENT_DATE, sp.last_updated) <= 180 THEN 0.75
                ELSE 0.6
            END
            *
            CASE sp.confidence_level
                WHEN 'HIGH' THEN 1.0
                WHEN 'MEDIUM' THEN 0.85
                ELSE 0.7
            END
            *
            CASE
                WHEN IFNULL(reg.regression_count,0) = 0 THEN 1.0
                WHEN reg.regression_count = 1 THEN 0.9
                WHEN reg.regression_count = 2 THEN 0.75
                ELSE 0.6
            END
        )
        / SUM(s.importance_weight)
    ,2) AS skill_readiness_index
FROM skill_progress sp
JOIN skills s ON sp.skill_id = s.skill_id
JOIN users u ON sp.student_id = u.user_id
LEFT JOIN (
    SELECT
        student_id,
        skill_id,
        COUNT(*) AS regression_count
    FROM skill_events
    WHERE event_type = 'REGRESSION'
      AND event_date >= DATE_SUB(CURRENT_DATE, INTERVAL 90 DAY)
    GROUP BY student_id, skill_id
) reg ON reg.student_id = sp.student_id AND reg.skill_id = sp.skill_id
GROUP BY u.user_id, u.name;
```

## 5️⃣ Interpreting SRI (Institutional Scale)

| SRI Range  | Interpretation          |
| ---------- | ----------------------- |
| **85–100** | Industry Ready          |
| **70–84**  | Nearly Ready            |
| **55–69**  | Needs Targeted Training |
| **< 55**   | At Risk                 |

This is **placement-cell friendly language**.

## 6️⃣ Mentor-Driven Actions Triggered by SRI

| Condition               | Action              |
| ----------------------- | ------------------- |
| SRI ↓ but Proficiency ↑ | Confidence issue    |
| SRI ↓ due to R          | Revision sprint     |
| SRI ↓ due to D          | Skill Gym re-enroll |
| SRI stable              | Industry project    |

## 7️⃣ Why This Is Powerful (Your Vision Realized)

This formula:

* Aligns **learning → employability**
* Converts **raw data → decisions**
* Enables **auto-remediation**
* Supports **dropout recovery**
* Makes AI-generated assessments meaningful

> **TFL doesn’t measure students.
> It measures readiness.**


## 🔜 Next Enhancements (Optional but Powerful)

1. **Role-based SRI** (Backend / Full-stack / DevOps)
2. **Skill cluster SRI** (OOP, Data, Systems)
3. **Time-series SRI trend graphs**
4. **AI explanation layer** (“Why is my SRI low?”)
5. **Employer-specific weighting**

If you want, next I can:

* Convert this into **stored procedure**
* Add **materialized snapshot table**
* Design **mentor dashboard widgets**
* Map **SRI → job role eligibility**



I’ve created a **complete mentor dashboard wireframe** in the canvas.

This wireframe is:

* **Mentor-first**, not admin-first
* Aligned with **TFL philosophy** (observe → diagnose → intervene)
* Ready to be used for **UI/UX design, frontend development, or stakeholder review**

### What you can do next (recommended sequence)

1. 🎨 **Convert wireframe → UI design** (Figma-style component mapping)
2. 🧱 **Map widgets → backend APIs & data models**
3. 🧠 **Attach AI insights** to each widget (rules + ML hooks)
4. 🧪 Design **mentor workflows** (1-day, 1-week mentoring loop)
5. 📱 Create **mobile mentor view** (lightweight, action-focused)

Tell me what you want next, Ravi:

* *“Convert this into API contracts”*
* *“Design database schema for widgets”*
* *“Create mentor journey flow”*
* *“Design student drill-down screen”*

I’ve created a **complete Mentor Journey Flow** in the canvas.

This is not just a flowchart — it’s a **behavioral model** of how mentors *think, decide, and act* inside **Transflower Learning Framework**.

### What this journey flow gives you

* ✅ Clear **daily / weekly / lifecycle** mentor loops
* ✅ Perfect alignment with your **mentor-driven, skill-first philosophy**
* ✅ Direct mapping to **dashboard widgets** you already designed
* ✅ Ready to be converted into:

  * Product requirements
  * API workflows
  * AI decision logic
  * Mentor training material

### Strong next steps (pick one)

1. 🧩 **Map each journey step → dashboard widgets + APIs**
2. 🧠 **Define AI rules per mentor step** (when to alert, suggest, stay silent)
3. 🗺 **Create student drill-down journey** (mentor → student perspective)
4. 🧪 **Design mentor effectiveness metrics**
5. 📘 Convert this into an **official TFL Mentor Playbook**

Just tell me the next direction, Ravi.




# 🗂️ TFL Mentor Dashboard – ER & Data Models

> **Purpose:** Translate the Mentor Journey Flow into concrete, implementation-ready **entities, relationships, and data models** that support dashboards, AI insights, and mentor actions.

---

## 🧠 Core Design Principles

1. **Skill is the central entity** (not course, not subject)
2. **Time-series data** for growth, regression, and trajectory
3. **Actions & observations** are first-class data (mentor intelligence)
4. **AI insights are derived**, not manually entered

---

## 1️⃣ Core Actors

### 👤 Mentor

* MentorId (PK)
* Name
* Email
* ExpertiseAreas
* ActiveStatus
* CreatedAt

### 👨‍🎓 Student

* StudentId (PK)
* Name
* Email
* CohortId (FK)
* BackgroundLevel (Beginner / Intermediate)
* OnboardedAt
* Status (Active / Dropped / Placed)

### 👥 Cohort

* CohortId (PK)
* Name
* TechnologyTrack (Java / .NET / Python / JS)
* StartDate
* EndDate
* MentorId (FK)



## 2️⃣ Skill & Curriculum Model (TFL Core)

### 🧩 Skill

* SkillId (PK)
* SkillName
* Category (Programming / DB / Architecture / DevOps)
* DifficultyLevel

### 📘 SkillConcept

* ConceptId (PK)
* SkillId (FK)
* ConceptName
* BloomLevel

### 🛣 SkillPath

* SkillPathId (PK)
* TargetRole (Backend / FullStack / DevOps)
* SkillId (FK)
* Weightage


## 3️⃣ Assessment & Performance

### 🧪 Assessment

* AssessmentId (PK)
* SkillId (FK)
* Type (MCQ / Coding / Scenario)
* Difficulty
* CreatedBy (Mentor / AI)

### ❓ Question

* QuestionId (PK)
* AssessmentId (FK)
* ConceptId (FK)
* QuestionType
* Difficulty

### 📊 AssessmentAttempt

* AttemptId (PK)
* AssessmentId (FK)
* StudentId (FK)
* Score
* AttemptedAt


## 4️⃣ Skill Intelligence (Most Important)

### 📈 SkillReadinessSnapshot

> Time-series table (used for trajectory & heatmap)

* SnapshotId (PK)
* StudentId (FK)
* SkillId (FK)
* ReadinessScore (0–100)
* ConfidenceScore
* CalculatedAt

### 🔁 SkillRegressionEvent

* RegressionId (PK)
* StudentId (FK)
* SkillId (FK)
* PreviousScore
* CurrentScore
* DetectedAt
* Severity (Low / Medium / High)

## 5️⃣ Mentor Actions & Journey

### ⚙ MentorAction

* ActionId (PK)
* MentorId (FK)
* StudentId (FK)
* ActionType (Nudge / Practice / 1:1 / Project)
* TriggerSource (AI / Manual)
* CreatedAt
* Status (Pending / Completed)

### 📋 MentorActionQueue

* QueueId (PK)
* MentorId (FK)
* ActionId (FK)
* PriorityScore
* DueDate

## 6️⃣ Projects & Job Readiness

### 🧩 Project

* ProjectId (PK)
* ProjectName
* Difficulty
* RoleMapping

### 🧠 ProjectSkillMap

* ProjectSkillMapId (PK)
* ProjectId (FK)
* SkillId (FK)
* CoverageLevel

### 🧪 StudentProject

* StudentProjectId (PK)
* StudentId (FK)
* ProjectId (FK)
* Status (Assigned / InProgress / Completed)
* MentorFeedback

## 7️⃣ Mentor Intelligence (Human Layer)

### ✍ MentorNote

* NoteId (PK)
* MentorId (FK)
* StudentId (FK)
* Context (Skill / Project / Behavior)
* NoteText
* CreatedAt

## 8️⃣ AI Insights & Patterns

### 🧠 MentorInsight

* InsightId (PK)
* Scope (Student / Cohort / Skill)
* ReferenceId (StudentId / CohortId / SkillId)
* InsightText
* GeneratedBy (AI)
* GeneratedAt

## 9️⃣ ER Relationship Summary (Textual)

```
Mentor 1 ──── * Cohort
Cohort 1 ──── * Student
Student * ──── * Skill (via SkillReadinessSnapshot)
Skill 1 ──── * SkillConcept
Skill 1 ──── * Assessment
Assessment 1 ──── * Question
Student 1 ──── * AssessmentAttempt
Student 1 ──── * MentorAction
Mentor 1 ──── * MentorNote
Student 1 ──── * StudentProject
Project * ──── * Skill
```

## 🔑 How This Supports Mentor Journey

| Mentor Step | Supporting Tables                            |
| ----------- | -------------------------------------------- |
| Observe     | SkillReadinessSnapshot, SkillRegressionEvent |
| Diagnose    | AssessmentAttempt, SkillConcept              |
| Decide      | MentorInsight                                |
| Act         | MentorAction, ActionQueue                    |
| Reflect     | MentorNote                                   |
| Evolve      | Cohort-level Insights                        |

## 🚀 Ready for Next Layer

This ER model is now ready to be converted into:

* Physical DB schema (MySQL)
* API contracts (REST / gRPC)
* AI feature pipelines
* Dashboard queries & views

> **TFL’s strength is not data collection — it is structured mentoring intelligence.**

Great question—**“Cohort”** is a very important concept in learning analytics and mentor dashboards.


## What is a Cohort? (Simple Meaning)

A **cohort** is a **group of learners who start or progress together under common conditions**.

👉 Think of a cohort as **“students who share the same journey”**.



## Cohort in Education (Real-Life Example)

Imagine you run a **.NET Full-Stack Program**.

* Batch Start Date: **1st July 2025**
* Duration: **6 months**
* Mentor: **Dr. Emma**

All students who:

* Joined on **1st July 2025**
* Follow the **same curriculum**
* Are mentored together

👉 This group is **one cohort**

> 📌 *“July 2025 .NET Full-Stack Cohort”*


## Cohort vs Batch vs Class

| Term                                                | Meaning                                     |
| --------------------------------------------------- | ------------------------------------------- |
| **Class**                                           | Physical or online session                  |
| **Batch**                                           | Operational grouping (schedule-based)       |
| **Cohort**                                          | **Analytical & learning-progress grouping** |
| **Cohort** focuses on **tracking growth over time** |                                             |



## Cohort in TFL (Transflower Learning Framework)

In **TFL**, a cohort typically groups students by:

* Start date
* Curriculum path
* Skill roadmap
* Mentor assignment

Example cohorts:

* `C# Beginner – Jan 2025 Cohort`
* `Full-Stack Developer – 2025 Cohort`
* `DevOps Bootcamp – Q3 2025 Cohort`


## Why Cohorts Matter (Mentor Perspective)

Cohorts allow mentors to:

- ✅ Compare students **fairly**
- ✅ Track **skill progression over time**
- ✅ Detect **dropout risk patterns**
- ✅ Measure **curriculum effectiveness**
- ✅ Run **cohort-based analytics**

Example questions mentors can answer:

* “How is **this cohort** performing vs last year?”
* “Which cohort has the **highest job readiness**?”
* “Where did **this cohort struggle** most?”


## Example: Cohort-Based Analytics

> “Average Readiness Index of **2025 .NET Cohort** = 78%
> Average Readiness Index of **2024 .NET Cohort** = 64%
> 📈 Curriculum improvement detected!”

## Cohort in Database Terms (Conceptual)

A cohort is usually represented by:

* `cohort_id`
* `cohort_name`
* `start_date`
* `end_date`
* `curriculum_id`
* `mentor_id`

Students are **mapped to a cohort**, not randomly mixed.

## Mentor Story (TFL Style)

> “Don’t judge a student alone.
> Judge **the journey they walked with others**.
> That journey is called a **cohort**.”


If you want, next I can:

* Add **Cohort tables** to your DB schema
* Write **cohort-based SQL analytics**
* Design **mentor dashboard widgets using cohorts**
* Explain **cohort vs skill-groups vs career-tracks**

Just tell me the direction 👍

