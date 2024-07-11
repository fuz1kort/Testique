# Testique

Инструкция по запуску:
  1. Создать миграции dotnet ef migrations add Initial
  2. Обновить базу данных dotnet ef database update
  3. Запустить Testique.API
  4. Запустить Testique.UI

Регистрация и авторизация пользователей
  • Возможность регистрации новых пользователей.
  • Возможность авторизации зарегистрированных пользователей.
  • Проверка уникальности электронной почты при регистрации.
  • Подтверждение электронной почты пользователя
  • Восстановление пароля через электронную почту.

Управление тестами
  • Возможность просмотра доступных тестов.
  • Возможность просмотра пройденных тестов и их результатов.
  • Возможность создания собственных тестов.

Создание тестов
  • Указание наименования тестирования.
  • Указание описания тестирования.
  • Возможность указания даты завершения доступа к тестированию или времени на прохождение теста.
  • Возможность создания теста на базе нескольких тестов (использование вопросов из других тестов).
  • Указание количества вопросов, которые будут случайным образом выбраны для каждого пользователя.

Поддержка различных типов вопросов:
  • Вопросы с множественным выбором.
  • Вопросы с расширенным ответом.
  • Вопросы на указание в нужном порядке.
  • Вопросы с единственно верным вариантом.

Прохождение тестов
  • Генерация ссылки на прохождение теста.
  • Авторизация пользователя перед началом теста (если не авторизован).
  • Отображение общего описания теста, времени на прохождение, количества возможных пересдач и максимально возможных баллов перед началом теста.
  • После прохождения теста отображение количества набранных баллов и количества верно отвеченных вопросов.

Анализ результатов
  • Возможность владельцу теста видеть, кто проходил тест, в какое время, количество попыток.
  • Возможность владельцу теста видеть, кто проходил тест.
  • Просмотр результатов прохождения каждого пользователя.
