plugins {
    id("com.android.library")
}

android {
    namespace = "com.example.newbinding"
    compileSdk = 34

    defaultConfig {
        minSdk = 21
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_1_8
        targetCompatibility = JavaVersion.VERSION_1_8
    }
}

dependencies {

    // Add package dependency for binding library. Uncomment line below and add your dependency.
    // implementation("dependency.name.goes.here")

    // Copy dependencies for binding library. Uncomment line below and add your dependency.
    // "copyDependencies"("dependency.name.goes.here")
}

// Copy dependencies for binding library. Uncomment code block below.
//project.afterEvaluate {
//    tasks.register<Copy>("copyDeps") {
//        from(configurations["copyDependencies"])
//        into("${projectDir}/build/outputs/deps")
//    }
//    tasks.named("preBuild") { finalizedBy("copyDeps") }
//}
