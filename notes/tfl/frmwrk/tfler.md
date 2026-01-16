# 🌸 Career OS Master Diagram (ASCII)

A **complete ASCII “Career OS Master Diagram”** that visualizes **all entities, relationships, and data flow** in the Transflower Learning Framework (TFL). This will **combine students, mentors, skills, plans, evidence, placement, and employer matching** — mentor- and developer-friendly.

```
                       +--------------------+
                       |     Students       |
                       |-------------------|
                       | student_id (PK)    |
                       | name               |
                       | email              |
                       | career_goal        |
                       +---------+----------+
                                 |
                                 v
                  +--------------+----------------+
                  | Student Skills / Skill Index  |
                  |-------------------------------|
                  | student_skill_id (PK)         |
                  | skill_id (FK)                 |
                  | score                         |
                  +--------------+----------------+
                                 |
                                 v
                       +---------+----------+
                       |       Skills       |
                       |--------------------|
                       | skill_id (PK)      |
                       | skill_name         |
                       | category           |
                       +-------------------+

                                  
+-----------------+       +-------------------+       +-------------------+
|     Mentors     |       |   Job Roles       |       |    Employers      |
|-----------------|       |-------------------|       |-----------------|
| mentor_id (PK)  |       | job_role_id (PK) |       | employer_id (PK) |
| name            |       | role_name        |       | name             |
| specialization  |       | level            |       | type             |
+--------+--------+       +---------+--------+       +--------+--------+
         |                          |                        |
         |                          |                        |
         v                          v                        v
+------------------+       +-------------------+     +-------------------+
| Quarterly Roadmaps|<-----> roadmap_skill_strategy |<-> Employer Matching |
|------------------|       |-------------------|     |-------------------|
| roadmap_id (PK)   |       | strategy_id (PK)  |     | match_id (PK)     |
| student_id (FK)   |       | roadmap_id (FK)   |     | student_id (FK)   |
| quarter_label     |       | skill_id (FK)     |     | employer_id (FK)  |
| target_role_id    |       | target_level      |     | job_role_id (FK)  |
+--------+---------+       +-------------------+     | fit_score         |
         |                                              | placement_prob    |
         v                                              +-------------------+
+------------------+
| Monthly Milestones|
|------------------|
| milestone_id (PK) |
| student_id (FK)   |
| milestone_month   |
| milestone_type    |
| status            |
+---------+---------+
          |
          v
+---------+-------------------+
| Milestone Skill Outcomes    |
|-----------------------------|
| outcome_id (PK)             |
| milestone_id (FK)           |
| skill_id (FK)               |
| starting_score              |
| expected_score              |
+-----------------------------+
          |
          v
+---------+-------------------+
| Milestone Projects          |
|-----------------------------|
| project_id (PK)             |
| milestone_id (FK)           |
| project_title               |
| completion_status           |
+-----------------------------+
          |
          v
+---------+-------------------+
| Milestone Evidence          |
|-----------------------------|
| evidence_id (PK)            |
| milestone_id (FK)           |
| evidence_type               |
| score                       |
+-----------------------------+

          |
          v
+----------------------------+
| Daily Learning Plans       |
|----------------------------|
| daily_plan_id (PK)         |
| student_id (FK)            |
| task_description           |
| completion_status          |
+----------------------------+

          |
          v
+----------------------------+
| Weekly Adaptive Plans       |
|----------------------------|
| weekly_plan_id (PK)         |
| student_id (FK)             |
| primary_focus              |
| expected_outcome           |
+----------------------------+

          |
          v
+----------------------------+
| Placement Probability      |
|----------------------------|
| score_id (PK)              |
| student_id (FK)            |
| probability_score           |
| confidence_level           |
+----------------------------+

          |
          v
+----------------------------+
| Mentor Interventions       |
|----------------------------|
| intervention_id (PK)       |
| student_id (FK)            |
| milestone_id (FK)          |
| roadmap_id (FK)            |
| action_type                |
| expected_impact            |
| actual_impact              |
+----------------------------+
```

## 🔹 How to Read This Diagram

1. **Student-centric**: Everything starts from `students`.
2. **Skill & Evidence Layer**:

   * `student_skills` tracks current ability
   * `milestones` + `projects` + `evidence` capture proof
3. **Plans Layer**:

   * Daily → Weekly → Monthly → Quarterly
4. **Placement Layer**:

   * `placement_probability_scores` evaluates employability
   * `mentor_interventions` act to increase probability
5. **Employer Layer**:

   * `employer_matching` connects students to opportunities
6. **Mentor Layer**:

   * Mentors act across roadmaps, milestones, and interventions


✅ **This diagram gives a full “Career OS” blueprint** showing:

* How **student execution** generates evidence
* How **mentor interventions** amplify placement
* How **system intelligence** computes probability
* How **employers see verified, placement-ready candidates**
