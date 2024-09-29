
import SwiftUI
import RealityKit
import Foundation
import UnityFramework

struct InjectRealityView: View{
    @State var showInjectView = false
    @State  var attachView : Entity?
    
    var body: some View {
 
        VStack{
            if(showInjectView){
                RealityView{ content, attachments in
                    attachView = attachments.entity(for: "inject_view")
                    if(attachView != nil)
                    {
                        attachView?.position = [0.3, 1.75, -1.2]
                        content.add(attachView!)
                    }
                } attachments: {
                    Attachment(id: "inject_view") {
                        InjectRealityContentView()
                    }
                }
            }
            else{
                RealityView{ content in
                }
            }
        }
        .frame(height: 500)
        .onAppear{
            SubscribeToUpdateInjectView { show in
                showInjectView = show
            }
            SubscribeUpdatePos(method: updatePos)
        }
    }
    
    func updatePos(x: Float, y: Float, z: Float){
        let pos = SIMD3(x, y, -z)
        attachView?.position = pos + [0.3, 0.45, 0]
    }
    
}

struct InjectRealityContentView: View{
    var body: some View {
        VStack(spacing: 30){
            Text("InjectView")
                .font(.title)
            
            Text("This is Inject RealityView")
                .font(.title3)
            
            Button {
                print("CLICK")
            } label: {
                Text("HelloButton")
                    .padding()
            }

        }
        .frame(width: 300, height: 300)
        .padding()
        .glassBackgroundEffect()
    }
}
