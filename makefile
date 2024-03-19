setup:
	dotnet tool restore
	npm install -E sql-formatter

format:
	dotnet csharpier .
	find . -type f -name '*.sql' | xargs -I% npx sql-formatter % --config .sql-formatter.json --fix

build:
	dotnet build -c Release --nologo -v q

test:
	dotnet test -c Release --no-build --nologo -v q

server:
	dotnet build server/src/Server.Host
	server/src/Server.Host/bin/Debug/net8.0/Server.Host

copy-dev-settings: clear-settings
	cp cfg/appsettings.json cfg/appsettings.local.json server/src/Server.Host/settings

copy-test-settings: clear-settings
	cp cfg/appsettings.json cfg/appsettings.test.json server/src/Server.Host/settings
	cp cfg/testsettings.json server/tests/Server.Host.Tests/settings

clear-settings:
	$(call mkdir,server/src/Server.Host/settings)
	$(call mkdir,server/tests/Server.Host.Tests/settings)

define mkdir
	@$(eval dir := $(1))
	rm -rf $(dir) && mkdir -p $(dir)
endef

.PHONY: $(MAKECMDGOALS)