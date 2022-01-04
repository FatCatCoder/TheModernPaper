# EF core with npgsql (postgres)

#### Auto gen dates and auto updated date
Data annotations unsupported, requires manual fluent api migration changes for .HasDefaultValueSql("now()") and for compute UpdatedAt column requires raw SQL function added to the database