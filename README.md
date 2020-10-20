# Contacts API

Small api created for the .NET Bootcamp at Digital Innovation One.

## Contact example
```json
{
    "id": "5f8e90b351fc7149466389ff",
    "firstName": "Dori",
    "lastName": "Pinching",
    "phone": "198236796679",
    "email": "dpinchingb@weather.com"
}
```

| HTTP VERB |       PATH      |       BODY PARAM       |    ROUTE PARAM    |    RETURN    |
|:---------:|:---------------:|:----------------------:|:-----------------:|:------------:|
|    POST   |   _/contact/_   | Contact to be inserted |       _none_      |    _none_    |
|    GET    |   _/contact/_   |         _none_         |       _none_      | All contacts |
|    PUT    | _/contact/{id}_ |     Updated contact    | Id of the contact |    _none_    |
|   DELETE  | _/contact/{id}_ |         _none_         | Id of the contact |    _none_    |