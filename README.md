# TASK API
## USER
### Register [POST]
> https://URL/api/User/register
1. Req Body ->
   - {
  "userName": "string",
  "email": "string",
  "password": "string"
}
2. Gereksinimler
   - Şifre minimum 6 karakter olmalı.
   - Şifre alfanümerik karakter içeremez. 
3. Responses
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber.
   - 201 Created -> Kayıt işlemi başarıyla gerçekleştiğinde.
  
### Login [POST]
> https://URL/api/User/login
1. Req Body ->
   - {
  "email": "string",
  "password": "string"
}
2. Gereksinimler
   - Şifre minimum 6 karakter olmalı.
   - Şifre alfanümerik karakter içeremez. 
3. Responses
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber.
   - 200 Ok -> Giriş işlemi başarıyla gerçekleştiğinde **{token:xxxx,usename:xxxx}**.
   - 401 Unauthorized -> Şifre yanlış olduğunda.
  
## TASK
### Create [POST]
> https://URL/api/Tasks
1. Req Body ->
   - {
  "title": "string",
  "description": "string"
}
2. Gereksinimler
   - Title zorunlu.
   - Description zorunlu değil.
   - Authorization.
3. Responses
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber.
   - 401 Unauthorized -> Authorization olmadığında.
   - 201 Created -> Oluşturma işlemi başarıyla gerçekleştiğinde.
  
### Edit [PUT]
> https://URL/api/Tasks/{id}
1. Req Body ->
   - {
  "id": 0,
  "title": "string",
  "description": "string"
}
2. Gereksinimler
   - Body'deki **id** ile URL'deki **id** aynı olması zorunlu.
   - Authorization.
3. Responses
   - 404 Not Found -> URL'den **id** gelmiyorsa veya **id** ile eşleşen **task** bulunamamışsa.
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber veya Body ile URL'deki **id**ler eşleşmiyorsa.
   - 204 No Content -> Düzenleme işlemi başarıyla gerçekleştiğinde.
   - 401 Unauthorized -> Authorization olmadığında.
### Delete [Delete]
> https://URL/api/Tasks/{id}
1. Gereksinimler
   - Url'deki id kısmı olması zorunlu.
   - Authorization.
3. Responses
   - 404 Not Found -> URL'den **id** gelmiyorsa veya **id** ile eşleşen **task** bulunamamışsa.
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber.
   - 204 No Content -> Silme işlemi başarıyla gerçekleştiğinde.
   - 401 Unauthorized -> Authorization olmadığında.
### All Tasks [GET]
> https://URL/api/Tasks
1. Responses
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber veya Body ile URL'deki **id**ler eşleşmiyorsa.
   - 200 Ok ->  İşlem başarıyla gerçekleştiğinde. ---- **[{
  "id": int,
  "title": "string",
  "description": "string"
  "createdAt": "string"
}, ...  ]**
### Get Task By Id [GET]
> https://URL/api/Tasks/{id}
1. Gereksinimler
   - Url'deki id kısmı olması zorunlu.
3. Responses
   - 404 Not Found -> URL'den **id** gelmiyorsa veya **id** ile eşleşen **task** bulunamamışsa.
   - 400 Bad Request -> Herhangi bir hata olduğunda mesajıyla beraber.
   -    - 200 Ok ->  İşlem başarıyla gerçekleştiğinde. ---- **{
  "id": int,
  "title": "string",
  "description": "string"
  "createdAt": "string"
}**



   
