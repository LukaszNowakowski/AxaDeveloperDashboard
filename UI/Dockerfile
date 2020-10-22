### STAGE 1: Build ###
FROM node:12.7-alpine AS build
WORKDIR /usr/src/app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build-prod

### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
COPY --from=build /usr/src/app/dist/Dashboard /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf

CMD ["/bin/sh",  "-c",  "exec nginx -g 'daemon off;'"]

Expose 80