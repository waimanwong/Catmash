# Catmash game

A Facemash-like game with cats ...

## Guidelines

This is a ASP.NET Core web application on top of a SQLServer hosted on Azure.
The style is a layered architecture : Web, Domain and Infrastrcture. We also constrain to a onion style centered around the domain.

## Web layer

This layer handles the http requests and invokes the domain services.

We implement a error handler middleware which handles the http response status code depending on the type of thrown exception.

## Domain layer

This is where the domain/business logic is implemented.

`BattleService` is responsible of initiating a new battle (randomly pick images) and register battle outcome (choice of the player).

A battleoutcome consists of a date of the battle and includes the selected image and the unselected image. The unselected image is not used for the moment but this may be interesting to record it for future purposes.

The validation of the battleOutcome isthe responsibility of `BattleOutcomeDtoValidator`. We use `FluentValidations` to implement these validations, this ensures in a large project that the validations are handled in the same way.

`ImageStatisticsProvider` returns the leaderboard statistics.

## Infrastructure Layer

The responsibility is to handle all database operations.

The `BattleOutcomeRepository` implements the repository pattern and the unit of work pattern.

The "providers" return data from the database that are not mutable, so we do not apply the repository pattern and we force EF to not track the returned data.

The database tables are image table, battleoutcome table.
We have a view which calculates the leaderboard.

## Tests

We unit test `BattleOutcomeDtoValidator` using XUnit, FluentAssertions and Moq.

## Ideas that were considered but dropped

- Having a mutable leader board: every time someone select an image we increment the counter. This was not considered because this does not support concurrent requests.
- Authentication: lack of time
- Limit the vote per IP: lack of time
- One person should see a battle only once: no authentication and lack of time.
- Avoid DDOS: lack of time.
- Counter cheatings: lack of time.
- Separate UnitOfWork.
- Separate Domain in a dedicated project (Modular monolith): may be overkilled here.
- Integration tests (test of the endpoints)

