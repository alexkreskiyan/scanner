setup:
	cd server && dotnet tool restore
	sudo npm install -g -E sql-formatter

format:
	cd server && dotnet csharpier .
	cd server && find . -type f -name '*.sql' | xargs -I% sql-formatter % --config .sql-formatter.json --fix

build:
	dotnet build server/Scanner.sln -c Release --nologo -v q

test:
	dotnet test server/Scanner.sln -c Release --no-build --nologo -v q

server:
	dotnet build server/src/Server.Host
	cd server/src/Server.Host && ENV=local ./bin/Debug/net8.0/Server.Host

configure-dev: clear-settings
	cp cfg/appsettings.json cfg/appsettings.local.json server/src/Server.Host/settings

configure-test: clear-settings
	cp cfg/appsettings.json cfg/appsettings.test.json server/src/Server.Host/settings
	cp cfg/testsettings.json server/tests/Server.Host.Tests/settings

clear-settings:
	$(call mkdir,server/src/Server.Host/settings)
	$(call mkdir,server/tests/Server.Host.Tests/settings)

db-drop:
	docker-compose rm -vfs db
	docker volume rm -f scanner_db
	docker-compose up -d db

define mkdir
	@$(eval dir := $(1))
	rm -rf $(dir) && mkdir -p $(dir)
endef

.PHONY: $(MAKECMDGOALS)
