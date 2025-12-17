# Sprintplan för Project3

Detta dokument beskriver ett förslag på sprintupplägg för projektet "Beställningssystem" (Blazor + SQL). Sprintarna är tvåveckors-sprintar (10 arbetsdagar). Anpassa datum efter era teamkalendrar.

Tidpunktsexempel (tvåveckors sprintar):
- Sprint 0 (Setup): 2025-12-17 → 2025-12-26 (kort initial sprint för miljö & infra)
- Sprint 1: 2026-01-05 → 2026-01-16
- Sprint 2: 2026-01-19 → 2026-01-30
- Sprint 3: 2026-02-02 → 2026-02-13

> Tips: Använd GitHub Milestones med samma namn (`Sprint 0`, `Sprint 1`, ...) och länka issues till rätt milestone.

## Övergripande mål per sprint

- Sprint 0 — Setup & CI
  - Mål: Körbar Docker-komposition, migrations på uppstart, projektstruktur och dokumentation.
  - Exempel-issues:
    - `infra: Ensure docker-compose startup with SQL and Blazor` (milestone: Sprint 0)
    - `ci: Add GitHub Actions workflow for build/publish` (milestone: Sprint 0)
    - `docs: Add architecture.md and sprints.md` (milestone: Sprint 0)
  - Acceptanskriterier: `docker-compose up --build` startar både `sql` och `blazor`; migrations körs och seed-data syns i appen.

- Sprint 1 — Core features
  - Mål: Grundläggande CRUD för Customers, Products, Orders; korrekt databasmodell och validering.
  - Exempel-issues:
    - `feat: Add create/edit/delete for Customer` (milestone: Sprint 1)
    - `feat: Add product catalog and SEK formatting` (milestone: Sprint 1)
    - `feat: Create order flow with OrderItems and PriceAtTimeOfPurchase` (milestone: Sprint 1)
  - Acceptanskriterier: UI kan skapa kunder/produkter/order; priser visas i `sv-SE`-format.

- Sprint 2 — Polishing & UX
  - Mål: UI-tema, accessibility, responsive, error handling, and client-side polish
  - Exempel-issues:
    - `ui: Two-color theme and nav contrast improvements` (milestone: Sprint 2)
    - `ux: Improve form validation and error messages` (milestone: Sprint 2)
    - `perf: Optimize page load and DB queries` (milestone: Sprint 2)
  - Acceptanskriterier: UI är responsiv, kontrast uppfyller WCAG 2.1 AA för nav header, felmeddelanden visas tydligt.

- Sprint 3 — Extras & hardening
  - Mål: Export/print orders, backups, DB precision, tests
  - Exempel-issues:
    - `feat: Export order to PDF` (milestone: Sprint 3)
    - `ops: Add SQL Server backup/restore notes and volume docs` (milestone: Sprint 3)
    - `test: Add integration tests for ordering flow` (milestone: Sprint 3)
  - Acceptanskriterier: Export fungerar, backups beskrivna/automatiserade, integrationstester finns.

## Prioriterad backlog (exempel)
- High
  - Order creation + PriceAtTimeOfPurchase
  - DB migrations on startup and seed data
  - Docker Compose / port mapping fixes
- Medium
  - UI theme & navigation contrast
  - SEK currency formatting
  - Product CRUD
- Low
  - PDF export
  - Extended tests, CI triggers

## GitHub setup (rekommenderat)
1. Labels (create these in repo settings -> Labels):
   - `type:bug`, `type:feature`, `type:chore`, `prio:high`, `prio:medium`, `prio:low`, `area:ui`, `area:infra`, `area:data`, `needs-review`
2. Milestones:
   - `Sprint 0`, `Sprint 1`, `Sprint 2`, `Sprint 3` (sätt due dates if ni önskar)
3. Projects (valfritt):
   - Skapa ett GitHub Projects board (kan användas som Kanban med kolumner To do / In progress / Review / Done)
4. Issue templates (repo har `.github/ISSUE_TEMPLATE/` för feature/bug)

### Snabbkommandon med `gh` (GitHub CLI)
(Om du har `gh` installerad och autentiserad)

```powershell
# skapa labels
gh label create "type:feature" --color F29500 --description "Feature or enhancement"
gh label create "type:bug" --color B60205 --description "Bug or defect"
gh label create "prio:high" --color 5319e7 --description "High priority"
# skapa milestones
gh milestone create "Sprint 0" --description "Setup and infra" --due "2025-12-26"
gh milestone create "Sprint 1" --description "Core features" --due "2026-01-16"
```

## Hur knyta issue till sprint
- Skapa issue, välj rätt labels och i högerpanelen välj Milestone → `Sprint 1`.

## Mall för sprintuppföljning (i milestone)
- Dagliga standups: kort notera blockerare i issue-kommentar
- Sprint review: skapa PRs och länka mot sprintens issues
- Retrospektiv: skapa ett `retro`-issue och tagga med `prio:low` och `area:process`

---

Vill du att jag automatiskt skapar exempel-issues i repo:n (jag kan generera draft-issues som Markdown-filer i `docs/` eller instruktioner för `gh issue create`)? Eller vill du att jag skapar en GitHub Project board-konfiguration (kan generera JSON för Projects v2 eller instruktioner för snabbsetup)? Säg vilken nivå av automation du önskar så kör jag vidare.