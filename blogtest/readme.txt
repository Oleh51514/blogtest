// commands for migration

add-migration -n MyMigr -c BlogDbContext -o Migrations -StartupProject blogtest.MvcApp

update-database -c BlogDbContext -StartupProject blogtest.MvcApp