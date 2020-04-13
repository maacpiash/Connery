<h1 align="center">Connery</h1>

<h3 align="center">
    Fruit Image Classifier Using Convolutional Neural Networks
</h3>

<p align="center">
    <a href="https://github.com/maacpiash/Connery/graphs/commit-activity">
        <img src="https://img.shields.io/badge/Status-WIP-yellow?style=flat-square" alt="Status">
    </a>
    <a href="https://www.igi-global.com/gateway/article/236206">
        <img src="https://img.shields.io/badge/DOI-10.4018%2FIJSI.2019100103-green?style=flat-square" alt="DOI">
    </a>
</p>


## Technical details

The project is developed using [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet). The web API is developed using [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet). Both these frameworks are free, cross-platform, and open-source.

The solution is divided into four projects:

- [`lib/Connery.Lib.csproj`](https://github.com/maacpiash/Connery/tree/master/lib): .NET Standard (class library) project that contains all the data structures for training, testing, and consuming the model.
- [`training/Connery.training.csproj`](https://github.com/maacpiash/Connery/tree/master/training): .NET Core console application that trains the model.
- [`testing/Connery.testing.csproj`](https://github.com/maacpiash/Connery/tree/master/testing): .NET Core console application that tests the model with some images that were not used for training.
- [`webapi/Connery.WebApi.csproj`](https://github.com/maacpiash/Connery/tree/master/webapi): ASP.NET Core web API (ReSTful) that receives an image via a POST request and returns the class of the image, with probability score.

The model used here is trained via applying [transfer learning](https://en.wikipedia.org/wiki/Transfer_learning) on Google's [Inception V3 model](https://github.com/tensorflow/models/tree/master/research/inception). Both the training and the generation of code (for training and consuming the model) was done using Visual Studio's [ML.NET Model Builder extension](https://marketplace.visualstudio.com/items?itemName=MLNET.07).

During the post-training evaluation, the model showed **89.02% accuracy**.

## Necessary assets

The [image dataset with images in labeled folders](https://1drv.ms/u/s!Al5VLgIxS8bWgeIgldY0x-GfxXWe6A?e=t3dUm2) should be downloaded and unzipped inside a directory named `assets` inside the root directory.

## File organization

Besides the `assets` directory, there should be an empty directory in the root folder named `workspace`, where the trained model will be.

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
└───workspace/
```

## Acknowledgement

This project was originally implemented as a course project during my CSE499 course at North South University over two semesters in 2018. I would like to thank my course supervisor, [Dr. Rashedur M. Rahman](http://ece.northsouth.edu/people/rashedur-rahman/).
