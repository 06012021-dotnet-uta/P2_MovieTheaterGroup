### STAGE 1: Build ###
FROM node:latest AS build
WORKDIR /src

#COPY package.json package-lock.json ./
COPY . .
RUN npm install

#COPY . .
RUN npm run build

### STAGE 2: Run ###
FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /src/dist/sampleAPI /usr/share/nginx/html
#when running on K8s you need to turn the daemon off.
#CMD ["nginx", "-g", "daemon off;"]
