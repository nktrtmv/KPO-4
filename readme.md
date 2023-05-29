Базы данных нужно подключать через docker-compose up -d из директории корня репозитория.

По необъяснимой причине в проекте Сервиса заказов не работал appsettings.json и конфигурация строки подключения к БД, поэтому connectionString захардкожен в 2 местах...

Миграции и все, что нужно происходит при запуске приложения, все что нужно - запустить через докер базы данных и потом запустить каждое из приложений.

Документация в сваггере!

Оба приложения написаны на чистой архитектуре с основным слоями (не считая абстракций):
- Presentation layer (Контроллеры и бэкграунд сервисы, конфигурация и запуск приложения)
- Application layer (Медиатор и логика приложения в целом)
- Domain layer (бизнес логика приложения)
- Infrastructure layer (слой работы с данными и все об этом, в общем Dal)