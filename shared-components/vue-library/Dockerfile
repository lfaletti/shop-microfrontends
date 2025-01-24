FROM node:latest as lib-build
WORKDIR /app

# Clear any existing node_modules and package-lock
COPY package.json ./
RUN rm -rf node_modules package-lock.json
RUN npm install

COPY . .
RUN npm run build

# Create a lightweight distribution image
FROM nginx:alpine
COPY --from=lib-build /app/dist /usr/share/nginx/html
EXPOSE 80
