# 🗄 Full Career OS Database Schema (MySQL)

This schema includes all layers:

1. **Student profile & core entities**
2. **Skills & Evidence engine**
3. **Daily → Weekly → Monthly → Quarterly plans**
4. **Placement probability & intervention engine**
5. **Employer matching & dashboards**

It’s **mentor-friendly**, **ML-ready**, and **employer-integrated**.

## 1️⃣ Core Entities

### `students`

```sql
CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone VARCHAR(20),
    enrollment_date DATE,
    career_goal VARCHAR(100),
    current_job_role_id INT,
    FOREIGN KEY (current_job_role_id) REFERENCES job_roles(job_role_id)
);
```

### `mentors`

```sql
CREATE TABLE mentors (
    mentor_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    specialization VARCHAR(100)
);
```

### `job_roles`

```sql
CREATE TABLE job_roles (
    job_role_id INT AUTO_INCREMENT PRIMARY KEY,
    role_name VARCHAR(100),
    level ENUM('Entry', 'Intermediate', 'Senior')
);
```

### `employers`

```sql
CREATE TABLE employers (
    employer_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100),
    type ENUM('Startup', 'ProductCompany', 'ServiceCompany', 'Enterprise'),
    industry VARCHAR(100)
);
```

## 2️⃣ Skills & Taxonomy

### `skills`

```sql
CREATE TABLE skills (
    skill_id INT AUTO_INCREMENT PRIMARY KEY,
    skill_name VARCHAR(100),
    category VARCHAR(50),
    level_required ENUM('Foundation', 'Intermediate', 'Advanced')
);
```

### `student_skills`

```sql
CREATE TABLE student_skills (
    student_skill_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    skill_id INT,
    score DECIMAL(5,2),
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

## 3️⃣ Daily / Weekly / Monthly / Quarterly Plans

### `daily_learning_plans`

```sql
CREATE TABLE daily_learning_plans (
    daily_plan_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    plan_date DATE,
    task_description TEXT,
    task_type ENUM('Learn','Practice','Assessment','Reflection','Project'),
    expected_duration_minutes INT,
    completion_status ENUM('Pending','Completed','Skipped') DEFAULT 'Pending',
    FOREIGN KEY (student_id) REFERENCES students(student_id)
);
```

### `weekly_learning_plans`

```sql
CREATE TABLE weekly_learning_plans (
    weekly_plan_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    week_start_date DATE,
    week_end_date DATE,
    primary_focus VARCHAR(100),
    secondary_focus VARCHAR(100),
    expected_outcome TEXT,
    FOREIGN KEY (student_id) REFERENCES students(student_id)
);
```

### `monthly_milestones`

```sql
CREATE TABLE monthly_milestones (
    milestone_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    milestone_month DATE NOT NULL,
    primary_job_role_id INT NOT NULL,
    milestone_title VARCHAR(150),
    milestone_description TEXT,
    expected_employability_level ENUM('Foundation','Intermediate','JobReady','InterviewReady') NOT NULL,
    milestone_type ENUM('SkillConsolidation','ProjectDelivery','InterviewReadiness','EmployerDriven') NOT NULL,
    generated_by ENUM('System','Mentor') DEFAULT 'System',
    generation_reason VARCHAR(255),
    status ENUM('Planned','InProgress','Achieved','PartiallyAchieved') DEFAULT 'Planned',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (student_id, milestone_month),
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (primary_job_role_id) REFERENCES job_roles(job_role_id)
);
```

### `milestone_skill_outcomes`

```sql
CREATE TABLE milestone_skill_outcomes (
    outcome_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,
    skill_id INT NOT NULL,
    starting_score DECIMAL(5,2),
    expected_score DECIMAL(5,2),
    criticality ENUM('Critical','Important','Supporting') DEFAULT 'Important',
    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

### `milestone_projects`

```sql
CREATE TABLE milestone_projects (
    project_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,
    project_title VARCHAR(150),
    project_description TEXT,
    tech_stack VARCHAR(255),
    evaluation_type ENUM('MentorReview','AutoAssessment','EmployerReview') DEFAULT 'MentorReview',
    completion_status ENUM('NotStarted','InProgress','Completed') DEFAULT 'NotStarted',
    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id)
);
```

### `milestone_interview_checkpoints`

```sql
CREATE TABLE milestone_interview_checkpoints (
    checkpoint_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,
    checkpoint_type ENUM('Technical','HR','SystemDesign','Behavioral'),
    expected_confidence_level INT CHECK (expected_confidence_level BETWEEN 1 AND 5),
    passed BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id)
);
```

### `milestone_evidence`

```sql
CREATE TABLE milestone_evidence (
    evidence_id INT AUTO_INCREMENT PRIMARY KEY,
    milestone_id INT NOT NULL,
    evidence_type ENUM('AssessmentScore','ProjectLink','MentorRating','EmployerFeedback'),
    evidence_reference VARCHAR(255),
    score DECIMAL(5,2),
    submitted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id)
);
```

### `quarterly_career_roadmaps`

```sql
CREATE TABLE quarterly_career_roadmaps (
    roadmap_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    quarter_label VARCHAR(20),
    quarter_start DATE NOT NULL,
    quarter_end DATE NOT NULL,
    target_job_role_id INT NOT NULL,
    target_employer_type ENUM('Startup','ProductCompany','ServiceCompany','Enterprise'),
    career_theme VARCHAR(150),
    positioning_statement VARCHAR(255),
    expected_employability_status ENUM('Exploration','SkillBuilding','JobReady','InterviewPipeline','Placed') NOT NULL,
    generated_by ENUM('System','Mentor') DEFAULT 'System',
    generation_reason VARCHAR(255),
    status ENUM('Planned','Active','Completed','Revised') DEFAULT 'Planned',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (student_id, quarter_label),
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (target_job_role_id) REFERENCES job_roles(job_role_id)
);
```

### `roadmap_skill_strategy`

```sql
CREATE TABLE roadmap_skill_strategy (
    strategy_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,
    skill_id INT NOT NULL,
    current_level DECIMAL(5,2),
    target_level DECIMAL(5,2),
    investment_priority ENUM('MustWin','StrongSupport','Maintain') NOT NULL,
    rationale VARCHAR(255),
    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id),
    FOREIGN KEY (skill_id) REFERENCES skills(skill_id)
);
```

### `roadmap_project_portfolio`

```sql
CREATE TABLE roadmap_project_portfolio (
    project_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,
    project_title VARCHAR(150),
    project_type ENUM('Capstone','EmployerSimulation','OpenSource','StartupPrototype'),
    core_skills VARCHAR(255),
    expected_business_value VARCHAR(255),
    completion_status ENUM('Planned','InProgress','Delivered') DEFAULT 'Planned',
    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

### `roadmap_interview_pipeline`

```sql
CREATE TABLE roadmap_interview_pipeline (
    pipeline_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,
    interview_type ENUM('DSA','Backend','Frontend','SystemDesign','HR','Behavioral'),
    readiness_level ENUM('NotReady','Practicing','MockCleared','EmployerCleared') DEFAULT 'NotReady',
    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

### `roadmap_risk_flags`

```sql
CREATE TABLE roadmap_risk_flags (
    risk_id INT AUTO_INCREMENT PRIMARY KEY,
    roadmap_id INT NOT NULL,
    risk_type ENUM('LowConsistency','SkillPlateau','ConfidenceGap','ProjectDelay','InterviewAvoidance'),
    severity ENUM('Low','Medium','High'),
    mitigation_plan TEXT,
    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

## 4️⃣ Placement Probability & Intervention

### `placement_probability_scores`

```sql
CREATE TABLE placement_probability_scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    prediction_window ENUM('30Days','60Days','90Days') NOT NULL,
    probability_score DECIMAL(5,2),
    confidence_level ENUM('Low','Medium','High'),
    dominant_factors VARCHAR(255),
    generated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id)
);
```

### `placement_model_features`

```sql
CREATE TABLE placement_model_features (
    feature_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    avg_skill_score DECIMAL(5,2),
    critical_skill_coverage DECIMAL(5,2),
    skill_growth_velocity DECIMAL(5,2),
    project_score DECIMAL(5,2),
    evidence_ratio DECIMAL(5,2),
    consistency_score DECIMAL(5,2),
    streak_days INT,
    interview_readiness_score DECIMAL(5,2),
    mentor_confidence_score DECIMAL(5,2),
    employer_fit_score DECIMAL(5,2),
    label_placed BOOLEAN,
    snapshot_date DATE,
    FOREIGN KEY (student_id) REFERENCES students(student_id)
);
```

### `mentor_interventions`

```sql
CREATE TABLE mentor_interventions (
    intervention_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    milestone_id INT,
    roadmap_id INT,
    action_type ENUM('MockInterview','ProjectReview','ConfidenceCoaching','SkillFocus','Other'),
    description TEXT,
    expected_impact DECIMAL(5,2), -- % probability gain
    actual_impact DECIMAL(5,2),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (milestone_id) REFERENCES monthly_milestones(milestone_id),
    FOREIGN KEY (roadmap_id) REFERENCES quarterly_career_roadmaps(roadmap_id)
);
```

## 5️⃣ Employer Matching & EMS

### `employer_matching`

```sql
CREATE TABLE employer_matching (
    match_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    employer_id INT NOT NULL,
    job_role_id INT NOT NULL,
    fit_score DECIMAL(5,2),
    placement_probability DECIMAL(5,2),
    status ENUM('Shortlisted','InterviewScheduled','Placed','Rejected') DEFAULT 'Shortlisted',
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (employer_id) REFERENCES employers(employer_id),
    FOREIGN KEY (job_role_id) REFERENCES job_roles(job_role_id)
);
```


✅ This **full schema** integrates all layers:

* Student, Mentor, Employer
* Skills & Evidence
* Daily → Weekly → Monthly → Quarterly plans
* Placement probability
* Mentor interventions
* Employer matching

It is **ML-ready**, **mentor-friendly**, and **employer-ready**.

 
