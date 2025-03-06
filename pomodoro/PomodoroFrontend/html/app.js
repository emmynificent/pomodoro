// DOM elements
const assignmentForm = document.getElementById('assignment-form');
const titleInput = document.getElementById('title');
const descriptionInput = document.getElementById('description');
const dueDateInput = document.getElementById('due-time');
const prioritySelect = document.getElementById('priority');
const setReminderCheckbox = document.getElementById('set-reminder');
const reminderTimeInput = document.getElementById('reminder-time');
const reminderTimeGroup = document.getElementById('reminder-time-group');
const remindersList = document.getElementById('reminders-list');

// Event listener to toggle the reminder time field
setReminderCheckbox.addEventListener('change', function () {
    reminderTimeGroup.style.display = this.checked ? 'block' : 'none';
});

function getAssignments() {
    fetch(baseApiUrl)
      .then((response) => response.json())
      .then((data) => {
        console.log("All Assignments:", data);
      })
      .catch((error) => console.error("Error fetching assignments:", error));
  }

  function getAssignment(assignmentId) {
    fetch(`${baseApiUrl}/${assignmentId}`)
      .then((response) => {
        if (!response.ok) {
          throw new Error(`Assignment with ID ${assignmentId} not found`);
        }
        return response.json();
      })
      .then((data) => {
        console.log(`Assignment ${assignmentId}:`, data);
      })
      .catch((error) => console.error("Error fetching assignment:", error));
  }
  function createAssignment(assignmentDto) {
    fetch(baseApiUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(assignmentDto),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to create assignment");
        }
        console.log("Assignment created successfully");
      })
      .catch((error) => console.error("Error creating assignment:", error));
  }

// Event listener for form submission
assignmentForm.addEventListener('submit', function (e) {
    e.preventDefault();

    // Get form values
    const title = titleInput.value;
    const description = descriptionInput.value;
    const createdTime = new Date().toLocaleString();
    const dueDate = new Date(dueDateInput.value).toLocaleString();
    const priority = prioritySelect.value;
    const reminderTime = setReminderCheckbox.checked ? reminderTimeInput.value : 'No reminder set';

    // Create a new reminder item
    const reminderItem = document.createElement('li');
    reminderItem.innerHTML = `
        <strong>${title}</strong> <br>
        Description: ${description} <br>
        Created on: ${createdTime} <br>
        Due: ${dueDate} <br>
        Priority: ${priority} <br>
        Reminder: ${reminderTime}
    `;
    remindersList.appendChild(reminderItem);

    // Reset form fields after submission
    assignmentForm.reset();
    reminderTimeGroup.style.display = 'none';
});
