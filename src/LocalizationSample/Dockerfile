# TODO use official docker image
FROM microsoft/dotnet:1.1.0-sdk-projectjson

# Install .NET CLI dependencies
RUN apt-get update && apt-get install -y --no-install-recommends \
		autoconf \
		automake \
		bzip2 \
		file \
		g++ \
		gcc \
		imagemagick \
		libbz2-dev \
		libc6-dev \
		libcurl4-openssl-dev \
		libdb-dev \
		libevent-dev \
		libffi-dev \
		libgdbm-dev \
		libgeoip-dev \
		libglib2.0-dev \
		libjpeg-dev \
		libkrb5-dev \
		liblzma-dev \
		libmagickcore-dev \
		libmagickwand-dev \
		libmysqlclient-dev \
		libncurses-dev \
		libpng-dev \
		libpq-dev \
		libreadline-dev \
		libsqlite3-dev \
		libssl-dev \
		libtool \
		libwebp-dev \
		libxml2-dev \
		libxslt-dev \
		libyaml-dev \
		make \
		patch \
		xz-utils \
		zlib1g-dev \
		postgresql-client \
	&& rm -rf /var/lib/apt/lists/*

# Install netcat so that we can ping the database server until it
RUN apt-get update -qq \
    && apt-get install -y netcat \
    && rm -rf /var/lib/apt/lists/*

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV DB_HOSTNAME="posgres"

# Copy files to app directory
COPY . /app

# Set working directory
WORKDIR /app

# Restore NuGet packages
RUN ["dotnet", "restore"]

# Build app
RUN ["dotnet", "build"]

#dotnet ef migrations add InitialCreate
RUN ["dotnet", "ef", "migrations", "add", "InitialCreate"]
# Open up port
EXPOSE 5000

CMD chmod +x ./docker-start.sh
CMD bash ./docker-start.sh
