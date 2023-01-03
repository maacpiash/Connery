## Connery API is offline due to Heroku ending free hosting. It will come back online soon. Thank you for checking out the repo.

<h1 align="center">Connery</h1>

<h3 align="center">
    Fruit Image Classifier Using Convolutional Neural Networks
</h3>

<p align="center">
    <a href="https://connery-api.herokuapp.com/">
        <img src="https://img.shields.io/badge/API-Swagger-brightgreen?logo=heroku&style=flat-square" alt="API Swagger">
    </a>
    <a href="https://github.com/maacpiash/Connery/actions?query=workflow%3AmacOS">
        <img src="https://img.shields.io/github/workflow/status/maacpiash/Connery/macOS?label=macOS&logo=apple&style=flat-square" alt="macOS build status">
    </a>
    <a href="https://github.com/maacpiash/Connery/actions?query=workflow%3AUbuntu">
        <img src="https://img.shields.io/github/workflow/status/maacpiash/Connery/Ubuntu?label=Ubuntu&logo=ubuntu&style=flat-square" alt="Ubuntu build status">
    </a>
    <a href="https://github.com/maacpiash/Connery/actions?query=workflow%3AWindows">
        <img src="https://img.shields.io/github/workflow/status/maacpiash/Connery/Windows?label=Windows&logo=microsoft&style=flat-square" alt="Windows build status">
    </a>
    <img src="https://img.shields.io/badge/Core-v3.1%20(LTS)-5C2D91?logo=.net&style=flat-square" alt=".NET Core SDK version 3.1 (LTS)">
</p>

## Technical details

The project is developed using [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet). The web API is developed using [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet). Both these frameworks are free, cross-platform, and open-source.

The solution is divided into four projects:

- [`lib/Connery.Lib.csproj`](/lib): .NET Standard (class library) project that contains all the data structures for training, testing, and consuming the model.
- [`training/Connery.training.csproj`](/training): .NET Core console application that trains the model.
- [`testing/Connery.testing.csproj`](/testing): .NET Core console application that tests the model with some images that were not used for training.
- [`webapi/Connery.WebApi.csproj`](/webapi): ASP.NET Core web API (ReSTful) that receives an image via a POST request and returns the class of the image, with probability score.

The model used here is trained via applying [transfer learning](https://en.wikipedia.org/wiki/Transfer_learning) on Google's [Inception V3 model](https://github.com/tensorflow/models/tree/master/research/inception). Both the training and the generation of code (for training and consuming the model) was done using Visual Studio's [ML.NET Model Builder extension](https://marketplace.visualstudio.com/items?itemName=MLNET.07).

The trained model can classify images into the following eight labels:

- `fresh_apple`
- `fresh_banana`
- `fresh_mango`
- `fresh_orange`
- `rotten_apple`
- `rotten_banana`
- `rotten_mango`
- `rotten_orange`

During the post-training evaluation, the model showed **89.02% accuracy**.

**[back to top](#connery)**

## How to use the application

The application, which is hosted on Heroku, is a ReSTful API. The API endpoint is [`/image`](https://connery-api.herokuapp.com/image). This endpoint can be called via a POST method, with request-body of type `form-data`, with the field `image` containing the image file.

Using `curl`, the command should be:

```shell
curl -X POST "https://connery-api.herokuapp.com/Image" -H  "accept: */*" -H  "Content-Type: multipart/form-data" -F "image=@<image-path>;type=image/jpeg"
```

Using [Postman](https://www.postman.com/), the configuration is like this:

![postman-screenshot](/docs/man/postman-screenshot.png)

The applicaton can also be used using Swagger, which has a GUI. Go to [this address](https://connery-api.herokuapp.com), then click on `POST` > `Try it out` > `Browse...` > `Execute`. After a few seconds, the result would be shown in the	"Response body" section.

![swagger-screenshot](/docs/man/swagger-screenshot.png)

**[back to top](#connery)**

## How to run the application on local machine

### Running binaries

Pre-built binaries for Windows (`x64`/`x86`), macOS, and Linux (`x64`/`arm`) can be found in the [releases](https://github.com/maacpiash/Connery/releases) section. Please download the suitable zip file and run the `publish/Connery.WebApi` file. For Windows builds, it's the `publish/Connery.WebApi.exe` file. 
The app can now be accessed from https://localhost:5001 or http://localhost:5000. There is also an `Assets.zip` file, which contains the images used for training and testing.

### Building from source

Compilation and building of the project would require .NET Core SDK (version 3.1), which can be downloaded from Microsoft's website [here](https://dot.net/get-core). This would also require `MLModel.zip` file, which can be found in the [releases](https://github.com/maacpiash/Connery/releases) section. Then,

- clone this repository
- go into the folder
- make a directory in `webapi` folder named `wwwroot` (`Connery/webapi/wwwroot`)
- move the `MLModel.zip` file inside `wwwroot` directory
- run the following command:

```shell
dotnet run -p webapi/Connery.WebApi.csproj
```

**[back to top](#connery)**

## How to train and test the model

If you want to train the model on your own machine, please download `Assets.zip` file from the [releases](https://github.com/maacpiash/Connery/releases) section. Then, unzip it inside a directory named `assets` inside the root directory. Besides this directory, there should be an empty directory in the root folder named `workspace`, where the trained model will be.

The file organization should be like this:

```shell
Connery/
├───assets/
│   ├───img_data/
│   │   ├───fresh_apple/
│   │   ├───fresh_banana/
│   │   ├───fresh_mango/
│   │   ├───fresh_orange/
│   │   ├───rotten_apple/
│   │   ├───rotten_banana/
│   │   ├───rotten_mango/
│   │   └───rotten_orange/
│   └───img_test/
├───lib/
│   └───Connery.Lib.csproj
├───testing/
│   └───Connery.Testing.csproj
├───training/
│   └───Connery.Training.csproj
├───webapi/
│   └───Connery.WebApi.csproj
├───workspace/
└───Connery.sln
```

### Training

To train the model, run the following command:

```shell
dotnet run -p training/Connery.Training.csproj
```

This will train the model from the images in `assets/img_data` folder and save the model at `workspace/MLModel.zip` path.

### Testing

Now, to test the model you just trained, run the following command:

```shell
dotnet run -p testing/Connery.Testing.csproj
```

This will test the model using the images in `assets/img_test` folder.

**[back to top](#connery)**

## Acknowledgement

This project was originally implemented as a course project during my CSE499 course at North South University over two semesters in 2018. I would like to thank my course supervisor, [Dr. Rashedur M. Rahman](http://ece.northsouth.edu/people/rashedur-rahman/). Without his generous guidance, we would not have been able to get our research published.

[![DOI](https://img.shields.io/badge/DOI-10.4018%2FIJSI.2019100103-green?style=flat-square)](https://www.igi-global.com/gateway/article/236206)


[![Twitter Follow](https://img.shields.io/twitter/follow/maacpiash?style=social)](https://twitter.com/maacpiash)

**[back to top](#connery)**
