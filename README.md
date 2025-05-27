# GitLabCommentImporter

📥 Утилита для получения комментариев к Merge Request из GitLab и экспорта их в CSV-файл.

## 🔧 Назначение

Скрипт подключается к GitLab API, загружает все комментарии (включая привязку к строкам кода, если есть) и сохраняет их в виде таблицы `report.csv`. Это удобно для анализа, аудита или передачи информации.

---

## 🚀 Как запустить

1. Склонируйте репозиторий:
   ```bash
   git clone https://github.com/your-org/GitLabCommentImporter.git
   cd GitLabCommentImporter
   ```

2. Установите зависимости:
   - .NET 6 или выше
   - GitLab access token с правами `api`

3. Отредактируйте `appsettings.json`:

   ```json
   {
     "GitLab": {
       "Url": "https://your.gitlab.instance",
       "ProjectId": "337",
       "MergeRequestIid": "2471",
       "PrivateToken": "your-access-token"
     },
     "Output": {
       "CsvPath": "report.csv"
     }
   }
   ```

4. Запустите утилиту:
   ```bash
   dotnet run --project GitLabCommentImporter
   ```

---

## 📄 Где появляется файл?

После успешного выполнения будет создан файл:

```
report.csv
```

Он будет находиться рядом с исполняемым проектом или по пути, указанному в `appsettings.json > Output > CsvPath`.

---

## 🔐 Как получить токен GitLab с правами `api`

1. Перейдите в GitLab → **Preferences** → **Access Tokens**  
   URL: `https://gitlab.example.com/-/profile/personal_access_tokens`

2. Установите:
   - Название (например, `CommentImporterToken`)
   - Срок действия (необязательно)
   - ✅ Выберите **scope**: `api`

3. Нажмите `Create personal access token`

4. **Скопируйте токен** и вставьте в `appsettings.json` → `PrivateToken`

---

## 📁 Структура проекта

```
GitLabCommentImporter/
├── Models/                      # Модели данных GitLab API
├── Services/                    # Загрузка комментариев
├── Export/                      # Экспорт в CSV
├── appsettings.json             # Конфигурация проекта
├── Program.cs                   # Точка входа
└── README.md                    # Описание и инструкция
```

---

## 📃 Пример CSV

```csv
File;Line;Comment;Author
src/main.cs;42;"Possible bug in logic";john.doe
README.md;N/A;"Please improve description";jane.dev
```

---

## 📜 Лицензия

MIT License.

---

# GitLabCommentImporter

📥 A utility that fetches comments from a GitLab Merge Request and exports them to a CSV file.

## 🔧 Purpose

This script connects to the GitLab API, downloads all comments (including inline code comments), and saves them to a CSV file (`report.csv`). It's useful for code review auditing and reporting.

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-org/GitLabCommentImporter.git
   cd GitLabCommentImporter
   ```

2. Requirements:
   - .NET 6 or higher
   - GitLab personal access token with `api` scope

3. Edit `appsettings.json`:

   ```json
   {
     "GitLab": {
       "Url": "https://your.gitlab.instance",
       "ProjectId": "337",
       "MergeRequestIid": "2471",
       "PrivateToken": "your-access-token"
     },
     "Output": {
       "CsvPath": "report.csv"
     }
   }
   ```

4. Run the utility:
   ```bash
   dotnet run --project GitLabCommentImporter
   ```

---

## 📄 Where is the output?

The resulting file:

```
report.csv
```

will be created in the working directory or at the path specified in `appsettings.json > Output > CsvPath`.

---

## 🔐 How to Generate a GitLab Access Token

1. Go to GitLab → **Preferences** → **Access Tokens**  
   URL: `https://gitlab.example.com/-/profile/personal_access_tokens`

2. Set:
   - Name (e.g., `CommentImporterToken`)
   - Expiry date (optional)
   - ✅ Select **scope**: `api`

3. Click `Create personal access token`

4. **Copy the token** and paste it into `appsettings.json` under `PrivateToken`

---

## 📁 Project Structure

```
GitLabCommentImporter/
├── Models/                      # GitLab API data models
├── Services/                    # Data fetching
├── Export/                      # CSV export
├── appsettings.json             # Configuration
├── Program.cs                   # Entry point
└── README.md                    # Project documentation
```

---

## 📃 CSV Example

```csv
File;Line;Comment;Author
src/main.cs;42;"Possible bug in logic";john.doe
README.md;N/A;"Please improve description";jane.dev
```

---

## 📜 License

MIT License.