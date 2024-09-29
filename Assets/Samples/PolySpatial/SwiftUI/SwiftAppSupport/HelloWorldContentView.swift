//
// This custom View is referenced by SwiftUISampleInjectedScene
// to provide the body of a WindowGroup. It's part of the Unity-VisionOS
// target because it lives inside a "SwiftAppSupport" directory (and Unity
// will move it to that target).
//

import Foundation
import SwiftUI
import UnityFramework

struct HelloWorldContentView: View {
    @State var counterObject = ObjectCounter()
    @State var fps = Float(90)

    var body: some View {
        VStack {
            Text("Hello, SwiftUI!")
            Divider()
                .padding(10)
            Text(String(format: "Unity Simulation FPS: %.1f", fps))
        }
        .onAppear {
           
        }

        // Changes to counterObject will result in updates to these text views
        HStack {
            
        }
        .padding(10)
    }
}

#Preview(windowStyle: .automatic) {
    HelloWorldContentView()
}
