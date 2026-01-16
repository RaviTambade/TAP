@echo off
REM ==============================================
REM Script to create Transflower Knowledge Base folders
REM ==============================================

echo Creating Transflower folders...

mkdir "00_vision_and_thoughts"
mkdir "01_tfl_framework"
mkdir "02_learning_methodology"
mkdir "03_roadmaps_and_plans"
mkdir "04_fullstack_stacks"
mkdir "05_tap_programs"
mkdir "06_technology_essentials"
mkdir "07_language_and_framework_essentials"
mkdir "08_ai_and_future"
mkdir "09_students_parents_mentors"
mkdir "10_industry_and_careers"
mkdir "11_people_and_stories"
mkdir "12_events_and_sessions"

echo All folders created successfully!
pause




@echo off
REM ==============================================
REM Script to create Transflower folders AND markdown files with placeholder text
REM ==============================================

echo Creating folders and markdown files...

REM ================= 00_vision_and_thoughts =================
mkdir "00_vision_and_thoughts"
for %%f in (vision biggestlie confusion empower developersuperpower greatsoftwaredev keepgoing startwithsmall restart seedtobloom openletter connect vibecoding jobremaintohuman) do (
    echo # %%f> "00_vision_and_thoughts/%%f.md"
    echo.>> "00_vision_and_thoughts/%%f.md"
    echo > "00_vision_and_thoughts/%%f.md"
)

REM ================= 01_tfl_framework =================
mkdir "01_tfl_framework"
for %%f in (tfl tflfrmwrk tflfromseedtoflwr tflfirstprinciple tflhumanfirst tflevidencefirst tfllearnops tfltt tflagility tflculture tflcharcterbuilding tflems tflempshere tfl.engine) do (
    echo # %%f> "01_tfl_framework/%%f.md"
    echo.>> "01_tfl_framework/%%f.md"
)

REM ================= 02_learning_methodology =================
mkdir "02_learning_methodology"
for %%f in (pbl bloomsTaxonomyTAP fiveetap stepbystep codingculture mentoring mentoringjourney sculpturepotmentoring craftsmanshipvschatgpt) do (
    echo # %%f> "02_learning_methodology/%%f.md"
)

REM ================= 03_roadmaps_and_plans =================
mkdir "03_roadmaps_and_plans"
for %%f in (roadmap jobreadinessfouryearplan tap4monthroadmap pythonfullstackroadmap industryready onedayfullstack studentdecesionguide) do (
    echo # %%f> "03_roadmaps_and_plans/%%f.md"
)

REM ================= 04_fullstack_stacks =================
mkdir "04_fullstack_stacks"
for %%f in (pythonfullstackroadmap mernfullstack javafullstack dotnetcorefullstack dotnetfullstack cppfullstack comparisionstacks technologydiversity becommingpolygotdeveloper polygotdeveloper polygotdeveloper2 ploygotdevmarathi) do (
    echo # %%f> "04_fullstack_stacks/%%f.md"
)

REM ================= 05_tap_programs =================
mkdir "05_tap_programs"
for %%f in (inductiontap inductionhandbook bootcamp tapdotnet tapjava tapnodejs tappython aiintap tflassessmentengine tflassessment) do (
    echo # %%f> "05_tap_programs/%%f.md"
)

REM ================= 06_technology_essentials =================
mkdir "06_technology_essentials"
for %%f in (computerscience layeredarchitecture timespacecomplexity webprogramming browsing localcodeglobalcloud machinecodetocloudproviders desktoptocloud interop ctocpp) do (
    echo # %%f> "06_technology_essentials/%%f.md"
)

REM ================= 07_language_and_framework_essentials =================
mkdir "07_language_and_framework_essentials"
for %%f in (CSharpessentials aspnetcoreessentials javafullstack cppfullstack mysqlessentials bootstrapessentials jqueryessentials softwaretestingessentials cicdessentials agileessentials) do (
    echo # %%f> "07_language_and_framework_essentials/%%f.md"
)

REM ================= 08_ai_and_future =================
mkdir "08_ai_and_future"
for %%f in (aiandme aifear evolutionai jobreplacebyai jobremaintohuman conversationwithchatgpt craftsmanshipvschatgpt) do (
    echo # %%f> "08_ai_and_future/%%f.md"
)

REM ================= 09_students_parents_mentors =================
mkdir "09_students_parents_mentors"
for %%f in (parentorientation FAQ invitation internrole internshipfinalyearstudents interviewguidlines studentdecesionguide successstories) do (
    echo # %%f> "09_students_parents_mentors/%%f.md"
)

REM ================= 10_industry_and_careers =================
mkdir "10_industry_and_careers"
for %%f in (hiringattransflower jobsustain jobdecline india_abroad_learning industryready softwaretflkitchen cheffullstackmeal) do (
    echo # %%f> "10_industry_and_careers/%%f.md"
)

REM ================= 11_people_and_stories =================
mkdir "11_people_and_stories"
for %%f in (abhaynavale pragatibangar tejaspawale) do (
    echo # %%f> "11_people_and_stories/%%f.md"
)

REM ================= 12_events_and_sessions =================
mkdir "12_events_and_sessions"
for %%f in (tflmakarsankranti 1_1_26) do (
    echo # %%f> "12_events_and_sessions/%%f.md"
)
REM Create session folders
mkdir "12_events_and_sessions/sessions"
mkdir "12_events_and_sessions/tfl"

echo All folders and placeholder markdown files created successfully!
pause

