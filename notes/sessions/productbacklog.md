
# 🗂️ Scrum Product Backlog – Chat App (Group Chat with Rooms)

Each item includes:

* **User Story**
* **Acceptance Criteria**
* **Priority (MoSCoW)**
* **Epic**

---

## ✅ EPIC 1: Authentication & User Management

### 1. `User Registration`

**As** a new user,
**I want** to register with a username, password, and email,
**So that** I can securely log into the chat application.

✅ *Acceptance:* Validations, duplicate check, MongoDB record.

**Priority:** Must Have

---

### 2. `Login with JWT`

**As** a user,
**I want** to log in using my credentials and receive a JWT token,
**So that** I can access secure routes.

✅ *Acceptance:* Token returned and used for protected APIs.

**Priority:** Must Have

---

### 3. `Logout`

**As** a user,
**I want** to log out,
**So that** my session ends securely.

✅ *Acceptance:* Token cleared, redirected to login.

**Priority:** Must Have

---

### 4. `Role-Based Access (Admin/User)`

**As** an admin,
**I want** to manage features based on roles,
**So that** only admins can access the dashboard and manage users.

✅ *Acceptance:* JWT contains role, middleware checks it.

**Priority:** Must Have

---

### 5. `Welcome Banner`

**As** a logged-in user,
**I want** to see a welcome message with my name,
**So that** I feel acknowledged.

**Priority:** Should Have

---

## 💬 EPIC 2: Real-Time Group Chat

### 6. `Join Room and Send/Receive Messages`

**As** a user,
**I want** to join a room and chat with others in real-time,
**So that** I can collaborate instantly.

✅ *Acceptance:* Socket.io room join, message broadcast, UI update.

**Priority:** Must Have

---

### 7. `Emoji Support in Chat`

**As** a user,
**I want** to send emojis in my chat messages,
**So that** I can express emotions better.

**Priority:** Could Have

---

### 8. `Typing Indicator`

**As** a user,
**I want** to know when someone is typing,
**So that** I can anticipate a reply.

**Priority:** Could Have

---

## 🔁 EPIC 3: Real-Time Features

### 9. `Online Users in Each Room`

**As** a user,
**I want** to see who is currently online in my room,
**So that** I know who I can talk to.

✅ *Acceptance:* Real-time update using Socket.io when user joins/leaves.

**Priority:** Must Have

---

### 10. `Real-time Dashboard Stats`

**As** an admin,
**I want** to see live counts of users/messages/uploads,
**So that** I can monitor activity in real-time.

**Priority:** Should Have

---

## 📁 EPIC 4: File Sharing

### 11. `Upload Images`

**As** a user,
**I want** to upload and send image files,
**So that** I can share visual content in the chat.

✅ *Acceptance:* Only image types, previewed in chat.

**Priority:** Must Have

---

### 12. `Upload Audio/Video`

**As** a user,
**I want** to share media files,
**So that** communication can be richer.

**Priority:** Should Have

---

### 13. `Upload Progress Bar`

**As** a user,
**I want** to see a progress bar during file uploads,
**So that** I know the status.

**Priority:** Should Have

---

### 14. `Cancel Upload`

**As** a user,
**I want** to cancel uploads,
**So that** I don’t waste bandwidth.

**Priority:** Could Have

---

### 15. `Validate File Types/Sizes`

**As** a user,
**I want** only allowed file types and sizes to upload,
**So that** I don’t crash the server or waste storage.

**Priority:** Must Have

---

### 16. `Upload Folder Limit per Room/User`

**As** an admin,
**I want** to restrict uploads per user or room,
**So that** we manage storage efficiently.

**Priority:** Could Have

---

## 🎨 EPIC 5: Canvas & Collaboration

### 17. `Multi-user Shared Canvas`

**As** a user,
**I want** to draw collaboratively with others,
**So that** we can brainstorm in real-time.

**Priority:** Should Have

---

### 18. `Save Canvas Snapshot (PNG)`

**As** a user,
**I want** to save canvas content as an image,
**So that** I can use it later.

**Priority:** Should Have

---

### 19. `Auto-Save Snapshots Every 5 Minutes`

**As** a user,
**I want** my canvas work to be saved automatically,
**So that** I don’t lose progress.

**Priority:** Could Have

---

### 20. `Undo Last Canvas Change`

**As** a user,
**I want** to undo my last drawing,
**So that** I can correct mistakes.

**Priority:** Should Have

---

### 21. `Clear/Reset Canvas`

**As** a user,
**I want** to clear the canvas,
**So that** I can start fresh.

**Priority:** Could Have

---

## 🛠️ EPIC 6: Admin Tools & Dashboard

### 22. `Admin Dashboard Summary`

**As** an admin,
**I want** a dashboard showing counts and graphs,
**So that** I can track usage.

**Priority:** Must Have

---

### 23. `Export Chat & Upload Logs`

**As** an admin,
**I want** to export logs to CSV or Excel,
**So that** I can analyze or report data.

**Priority:** Should Have

---

### 24. `User Management (View/Delete/Role)`

**As** an admin,
**I want** to manage users and roles,
**So that** I can maintain order.

**Priority:** Must Have

---

## 🧑‍🎨 EPIC 7: UI/UX Features

### 25. `Mobile-Friendly UI`

**As** a user,
**I want** the UI to work on mobile,
**So that** I can chat on the go.

**Priority:** Must Have

---

### 26. `Dark Mode Toggle`

**As** a user,
**I want** to switch between light and dark themes,
**So that** I can reduce eye strain.

**Priority:** Should Have

---

### 27. `Use Bootstrap or Tailwind`

**As** a developer,
**I want** to build the frontend using a modern CSS framework,
**So that** I can develop faster and ensure responsiveness.

**Priority:** Must Have

---

## 🔄 EPIC 8: Screen Sharing (Optional Advanced)

### 28. `Live Screen Sharing`

**As** a user,
**I want** to share my screen with others in a room,
**So that** I can present or collaborate live.

**Priority:** Could Have

---

## 📦 EPIC 9: File & Snapshot Archival

### 29. `Upload Snapshot with Naming`

**As** a user,
**I want** to name snapshots when uploading,
**So that** I can find them later.

**Priority:** Should Have

---

### 30. `Store Snapshots in User/Room Folders`

**As** a system,
**I want** to store snapshots in folders by user or room,
**So that** files stay organized.

**Priority:** Should Have

---

### 31. `Zip and Export All Saved Images`

**As** a user,
**I want** to download all my snapshots as a ZIP file,
**So that** I can archive my work.

**Priority:** Could Have

---

## ✅ Format for Jira/Trello

Each story can be entered with:

* **Title**
* **Story (As a … I want … So that …)**
* **Priority**
* **Labels**: `auth`, `chat`, `admin`, `realtime`, `file`, `canvas`
* **Epic Link** (from above)

---

