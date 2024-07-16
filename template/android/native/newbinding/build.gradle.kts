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

// Create configuration for copyDependencies
configurations {
    create("copyDependencies")
}

dependencies {

    // Add package dependency for binding library
    // Uncomment line below and replace dependency.name.goes.here with your dependency
    // implementation("dependency.name.goes.here")

    // Copy dependencies for binding library
    // Uncomment line below and replace dependency.name.goes.here with your dependency
    // "copyDependencies"("dependency.name.goes.here")
}

// Copy dependencies for binding library
project.afterEvaluate {
    tasks.register<Copy>("copyDeps") {
        from(configurations["copyDependencies"])
        into("${projectDir}/build/outputs/deps")
    }
    tasks.named("preBuild") { finalizedBy("copyDeps") }
}
