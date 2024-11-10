The Unity Associate Game Developer course involves a series of units,
introducing the editor and the managerment of different aspects of
scenes and objects.  This is a simple template with:
 - a (empty) sub-directory for each unit
 - .gitignore to exclude built (vs created) items

The intent is that students will fork this repo and then do the work
in their own fork.  The expected form of a submission is a github
URL for the (public) repo in which you have done your work.

To do one of the units:
 - create a new project
 - in this top level directory
 - with the same name as the unit sub-directory (e.g. *Unit_1-Unity_Basics*)

The *.gitignore* file in this directory commits only the configuration, assets
and code created for that unit.  It ignores all of the standard libraries and
tools that are automatically pulled (by *unityhub*) into each new project.
When the repo is re-cloned *Unity* will automatically pull all of that stuff
in to the recovered project.

If you want to export a project from one system so that you can work
on it on another, the easiest way to do it is:
   1. in Project window, right-click the Assets folder and select Export Package
   2. in the resulting dialog, review the list and click Export
   3. give the package an identifying name (e.g student name and project #)

Such an export should be platform independent, so that a project developed
on a Windows system can be imported into and run on a Linux system.

[I have also heard that it is possible to export a project as a zip of
the Assets, Packages, and Project Settings folders ... but I have not
yet done this]
