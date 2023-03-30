FROM professorapplication:dev

ENV ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=https://+:443;http://+:80
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV NUGET_PACKAGES=/root/.nuget/fallbackpackages
ENV NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages
ENV PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_VERSION=6.0.15
ENV ASPNET_VERSION=6.0.15

WORKDIR /app

COPY ./ProfessorApplication /app
COPY ./ /src/

VOLUME /root/.nuget/fallbackpackages
VOLUME /remote_debugger
VOLUME /root/.microsoft/usersecrets
VOLUME /root/.aspnet/https

EXPOSE 443
EXPOSE 80

ENTRYPOINT ["tail", "-f", "/dev/null"]