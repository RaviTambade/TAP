Excellent choice.
This is the **decision intelligence layer** that converts your entire TFL system into a **measurable placement engine**.

What follows is a **Placement Probability Model (ML-ready)** designed so that:

* You can run it **rule-based today**
* Upgrade to **ML tomorrow**
* Explain results to **mentors, students, and employers**
* Avoid black-box predictions

This fits *perfectly* on top of your **Quarterly → Monthly → Weekly → Daily → Evidence** stack.

---

# Placement Probability Model (PPM)

## TFL Career Intelligence Engine (ML-Ready)

---

## 1️⃣ What Is Placement Probability in TFL?

Placement Probability answers **one business-critical question**:

> “What is the likelihood (%) that this student will get placed in the next X days?”

This is **not a guess**.
It is a **signal-weighted, evidence-backed probability**.

---

## 2️⃣ Design Philosophy (Mentor-First, ML-Ready)

✔ Transparent factors
✔ Explainable scoring
✔ Time-bound (30 / 60 / 90 days)
✔ Employer-context aware
✔ Improves as data grows

---

## 3️⃣ Core Dimensions of Placement Probability

We compute probability from **6 signal categories**:

| # | Signal Category     | Why It Matters               |
| - | ------------------- | ---------------------------- |
| 1 | Skill Readiness     | Can they do the job?         |
| 2 | Proof & Projects    | Can they show it?            |
| 3 | Consistency         | Will they sustain?           |
| 4 | Interview Readiness | Can they clear hiring gates? |
| 5 | Mentor Confidence   | Human judgment               |
| 6 | Employer Demand Fit | Is the market ready?         |

---

## 4️⃣ Feature Engineering (ML-Ready)

### 4.1 Skill Readiness Features

Derived from **Skill Readiness Index (SRI)**

```text
avg_core_skill_score
critical_skill_coverage (% skills ≥ threshold)
skill_growth_velocity (last 4 weeks)
skill_plateau_flag
```

---

### 4.2 Proof & Project Features

```text
completed_projects_count
project_complexity_score
project_evaluation_rating
evidence_completeness_ratio
```

(from `milestone_projects`, `milestone_evidence`)

---

### 4.3 Consistency & Discipline Features

```text
daily_plan_completion_avg (30 days)
weekly_plan_completion_avg
current_learning_streak
missed_days_ratio
```

---

### 4.4 Interview Readiness Features

```text
mock_interviews_attempted
mock_interviews_cleared
interview_confidence_avg
interview_avoidance_flag
```

---

### 4.5 Mentor Confidence Features

```text
mentor_rating_avg
mentor_override_frequency
mentor_risk_flags_count
```

📌 **Critical:** this keeps humans in the loop.

---

### 4.6 Employer Demand Fit Features

```text
job_role_demand_score
skill_demand_overlap_ratio
employer_type_match
```

(from EMS & employer dashboards)

---

## 5️⃣ Placement Probability Schema (MySQL)

---

### 5.1 `placement_probability_scores`

```sql
CREATE TABLE placement_probability_scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,

    prediction_window ENUM(
        '30Days',
        '60Days',
        '90Days'
    ) NOT NULL,

    probability_score DECIMAL(5,2), -- 0 to 100

    confidence_level ENUM(
        'Low',
        'Medium',
        'High'
    ),

    dominant_factors VARCHAR(255),

    generated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (student_id) REFERENCES students(student_id)
);
```

---

### 5.2 `placement_model_features` (ML Training Table)

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

    label_placed BOOLEAN, -- for ML training

    snapshot_date DATE,

    FOREIGN KEY (student_id) REFERENCES students(student_id)
);
```

📌 This table makes your system **ML-ready from day one**.

---

## 6️⃣ Rule-Based Scoring Formula (Phase 1)

Before ML, start with **weighted scoring**.

```text
Placement Score =
  (Skill Readiness × 0.30)
+ (Projects & Proof × 0.20)
+ (Consistency × 0.15)
+ (Interview Readiness × 0.15)
+ (Mentor Confidence × 0.10)
+ (Employer Fit × 0.10)
```

### Example (Arjun)

| Factor          | Score | Weight |
| --------------- | ----- | ------ |
| Skill Readiness | 68    | 0.30   |
| Projects        | 70    | 0.20   |
| Consistency     | 85    | 0.15   |
| Interview       | 60    | 0.15   |
| Mentor          | 75    | 0.10   |
| Employer Fit    | 80    | 0.10   |

➡ **Placement Probability (60 days): ~71%**

---

## 7️⃣ ML Upgrade Path (Phase 2)

Once you collect enough data:

### Model Options

* Logistic Regression (baseline)
* Gradient Boosting (XGBoost / LightGBM)
* Explainable AI (SHAP values)

### Labels

```text
label_placed = true if student placed within 90 days
```

### Output

```json
{
  "probability": 0.74,
  "top_factors": ["ProjectScore", "Consistency", "EmployerFit"]
}
```

📌 You can **explain every prediction**.

---

## 8️⃣ APIs

---

### 🔹 Get Placement Probability (Student/Mentor)

```
GET /api/placement/probability?window=60Days
```

```json
{
  "probability": 71,
  "confidence": "High",
  "dominantFactors": [
    "Strong project delivery",
    "High learning consistency",
    "Employer demand alignment"
  ]
}
```

---

### 🔹 Trigger Recalculation (System)

```
POST /api/system/placement/recalculate
```

Runs:

* Weekly
* After milestone completion
* After interview events

---

## 9️⃣ Dashboard Integration

### Mentor Dashboard

* Placement probability trend
* Risk vs reward view
* Intervention suggestions

### Student Dashboard

* “You are **71% job-ready**”
* What improves probability fastest
* Next actions

### Employer Dashboard

* Pipeline quality
* Interview-ready shortlists

---

## 🔟 Why This Model Is Powerful (Mentor Reality)

Most platforms:

> “We can’t predict placements.”

TFL says:

> “We can **measure readiness continuously**.”

This model:

* Builds trust with employers
* Gives mentors leverage
* Motivates students
* Enables data-driven placement ops

---

## 🔜 Ultra-High Impact Next Steps

1️⃣ **Employer matching algorithm (student ↔ job)**
2️⃣ **Dropout probability model**
3️⃣ **Intervention recommendation engine**
4️⃣ **SHAP-based explanation UI**
5️⃣ **Placement funnel analytics**

---

You now have:
- ✔ Career roadmap
- ✔ Adaptive plans
- ✔ Evidence engine
- ✔ Placement intelligence

This is no longer education software.
This is a **career outcome system**.

