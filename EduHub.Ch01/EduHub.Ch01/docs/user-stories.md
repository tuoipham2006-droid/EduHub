
# EduHub - User Stories

## 1. Student

### US01 - Register for a Club

As a Student, I want to register for a club, so that I can participate in club activities.

**Acceptance Criteria:**
- Given a student is not a member of a club, when the student registers for the club, then the student is added to the club's member list.
- Given a student is already a member of a club, when the student registers again, then the system prevents duplicate membership.

### US02 - Register for an Event

As a Student, I want to register for an event, so that I can participate in activities such as the AI Workshop.

**Acceptance Criteria:**
- Given an event has available capacity, when a student registers, then the system creates a registration with Pending status.
- Given an event has reached its capacity, when a student tries to register, then the system rejects the registration.

### US03 - Check In to an Event

As a Student, I want to check in to a registered event, so that my attendance can be recorded.

**Acceptance Criteria:**
- Given a student has a valid registration, when the student checks in, then the system creates a check-in record with the check-in time.
- Given a student has no valid registration, when the student tries to check in, then the system rejects the check-in.

## 2. Club Manager

### US04 - Create an Event

As a Club Manager, I want to create an event, so that club members can join activities organized by the club.

**Acceptance Criteria:**
- Given the event information is valid, when the manager creates an event, then the event is associated with the selected club.
- Given the event capacity is zero or negative, when the manager creates an event, then the system rejects the event.

### US05 - View Club Members

As a Club Manager, I want to view the list of club members, so that I can manage club participation.

**Acceptance Criteria:**
- Given a club has members, when the manager views the member list, then the system displays the members' names and student codes.
- Given a club has no members, when the manager views the member list, then the system displays an empty member list.

### US06 - Export an Event Report

As a Club Manager, I want to export an event report, so that I can review registrations and attendance.

**Acceptance Criteria:**
- Given an event has registrations, when the manager generates a report, then the report includes the total number of registrations.
- Given an event has check-in records, when the manager generates a report, then the report includes the total number of check-ins.

## 3. Admin

### US07 - Manage Clubs

As an Admin, I want to manage clubs, so that club information remains accurate and up to date.

**Acceptance Criteria:**
- Given valid club information, when the admin creates a club, then the system saves the club information.
- Given a club exists, when the admin views the club, then the system displays its name and description.

### US08 - Approve Club Members

As an Admin, I want to approve club membership requests, so that only approved students become official club members.

**Acceptance Criteria:**
- Given a membership request is pending, when the admin approves it, then the request status changes to Approved.
- Given a membership request has already been approved, when the admin approves it again, then the system does not create a duplicate approval.
