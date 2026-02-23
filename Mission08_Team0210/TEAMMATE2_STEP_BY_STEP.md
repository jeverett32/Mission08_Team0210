# Teammate 2 Step-by-Step Guide (Updated For Current Branch)

This is your scope only:
- Shared layout and navigation
- Add/Edit Task Razor view
- Bootstrap Grid and UI consistency

Do not edit repository/database/controller logic unless your team reassigns work.

## Current code snapshot you should build against
From the latest pulled controller (`HomeController`):
- `Index()` displays incomplete tasks
- `AddEditTask()` GET returns `View(new TaskModel())` and sets `ViewBag.Categories`
- `AddEditTask(TaskModel response)` POST saves task and redirects to `Index`
- `Edit(int id)` returns `View("AddEditTask", task)` and sets `ViewBag.Categories`
- `Delete(...)` is wired, but Delete UI is not your assignment

That means your Add/Edit view file should be:
- `Mission08_Team0210/Views/Home/AddEditTask.cshtml`

## 1. Switch to your branch
From repo root:

```bash
git checkout Noah_Blake
```

## 2. Run the app baseline once

```bash
dotnet run --project Mission08_Team0210
```

## 3. Update shared layout nav
Edit:
- `Mission08_Team0210/Views/Shared/_Layout.cshtml`

Replace template nav links with mission links:
- Home (`Home/Index`)
- Add Task (`Home/AddEditTask`)
- Quadrants (`Home/Index` for now, until teammate 3/4 adds a dedicated quadrants action)

Example links:

```cshtml
<a class="nav-link text-dark" asp-controller="Home" asp-action="Index">Home</a>
<a class="nav-link text-dark" asp-controller="Home" asp-action="AddEditTask">Add Task</a>
<a class="nav-link text-dark" asp-controller="Home" asp-action="Index">Quadrants</a>
```

Also remove `Privacy` references from navbar/footer since no `Privacy` action exists now.

## 4. Create the Add/Edit view
Create:
- `Mission08_Team0210/Views/Home/AddEditTask.cshtml`

Use the task model your teammates added (likely `TaskModel`):

```cshtml
@model TaskModel
```

If namespaced in your project, use the full type (example: `Mission08_Team0210.Models.TaskModel`).

## 5. Build one form for both Add and Edit
Use one form posting to `Home/AddEditTask`:

```cshtml
<form asp-controller="Home" asp-action="AddEditTask" method="post">
```

Include hidden ID field for edits (property name based on model, usually `TaskId`).

## 6. Include all required fields
Build UI fields for:
- Task (required)
- Due Date
- Quadrant (required)
- Category (dropdown)
- Completed (checkbox)

Use `ViewBag.Categories` for dropdown options because controller already provides it.

## 7. Use Bootstrap Grid layout
Keep the page responsive:

```cshtml
<div class="container">
  <div class="row justify-content-center">
    <div class="col-12 col-md-8 col-lg-6">
      <!-- form card -->
    </div>
  </div>
</div>
```

Use standard classes like `form-label`, `form-control`, `form-select`, `mb-3`, `btn btn-primary`.

## 8. Add validation UI
In your form:
- `asp-validation-summary="All"`
- `asp-validation-for` on each field

At bottom of view:

```cshtml
@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

If missing, create:
- `Mission08_Team0210/Views/Shared/_ValidationScriptsPartial.cshtml`

With:

```cshtml
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>
```

## 9. Add/Edit display behavior
Set heading/button text based on ID:
- New task: `Add Task` / `Create Task`
- Existing task: `Edit Task` / `Save Changes`

Use the same view for both Add and Edit.

## 10. Test your assigned features
Checklist:
- Navbar renders and all links work
- `Home/AddEditTask` loads
- `Home/Edit/{id}` loads and pre-populates fields
- Category dropdown displays values
- Required field validation appears for Task and Quadrant
- Form layout is clean on mobile and desktop widths

## 11. Commit only your teammate-2 files

```bash
git add Mission08_Team0210/Views/Shared/_Layout.cshtml
git add Mission08_Team0210/Views/Home/AddEditTask.cshtml
git add Mission08_Team0210/Views/Shared/_ValidationScriptsPartial.cshtml
git add Mission08_Team0210/TEAMMATE2_STEP_BY_STEP.md
git commit -m "Teammate 2: layout + add/edit task view"
git push
```

## Ownership boundaries for grading
- You: shared layout/nav + Add/Edit task view + Bootstrap Grid consistency
- Teammate 1: models, DB, repository, Program.cs setup
- Teammate 3: quadrants page UI + update/delete controls on that page
- Teammate 4: controller logic, GitHub merges, submission/project management
